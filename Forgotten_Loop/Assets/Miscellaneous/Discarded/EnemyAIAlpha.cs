using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIAlpha : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private float ChaseThreshold = 3f, AttackThreshold = 0.8f;

    [SerializeField]
    public float attackDelay = 1f;
    public float passedTime = 1f;


    public void Start()
    {
        Player = GameObject.Find("Player");
    }
    public void Update()
    {
        if(Player==null)
            return;

        float distance = Vector2.Distance(Player.transform.position, transform.position);
        if (distance < ChaseThreshold)
        {
            OnPointerInput?.Invoke(Player.transform.position);
            if (distance <= AttackThreshold)
            {
                OnMovementInput?.Invoke(Vector2.zero);

                   if (passedTime >= attackDelay)
                   {
                       passedTime = 0;
                       OnAttack?.Invoke();
                   }
            }
            else
            {
                Vector2 direction = Player.transform.position- transform.position;
                OnMovementInput?.Invoke(direction.normalized);
            }
        }
        else
        {
            OnMovementInput?.Invoke(Vector2.zero);
        }
        if (passedTime < attackDelay)
        {
            passedTime += Time.deltaTime;
        }
    }
}
