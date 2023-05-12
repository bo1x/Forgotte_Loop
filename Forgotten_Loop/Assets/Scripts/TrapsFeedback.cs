using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsFeedback : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ImpactoPlayer(collision));
        }
    }

    public IEnumerator ImpactoPlayer(Collider2D collision)
    {
        collision.gameObject.GetComponent<VidaPj>().VidaActual--;
        Vector2 dir = (transform.position - GameObject.Find("Player").transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 20, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        collision.gameObject.GetComponent<Control>().enabled = true;
    }
}
