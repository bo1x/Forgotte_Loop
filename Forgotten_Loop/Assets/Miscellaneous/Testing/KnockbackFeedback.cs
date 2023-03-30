using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myrigi;

    [SerializeField]
    private float strength = 16, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }
    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        myrigi.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        myrigi.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}
