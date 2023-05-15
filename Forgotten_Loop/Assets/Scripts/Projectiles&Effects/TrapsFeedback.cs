using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsFeedback : MonoBehaviour
{
    public Animator myanim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Impacto(collision));
        }
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(ImpactoEnemy(collision));
        }

    }

    public IEnumerator Impacto(Collider2D collision)
    {
        collision.gameObject.GetComponent<VidaPj>().VidaActual--;
        Vector2 dir = (transform.position - collision.transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 50, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        collision.gameObject.GetComponent<Control>().enabled = true;
    }

    public IEnumerator ImpactoEnemy(Collider2D collision)
    {
      //  collision.gameObject.GetComponent<VidaPj>().VidaActual--;
        Vector2 dir = (transform.position - collision.transform.position).normalized;
        collision.gameObject.GetComponent<AgentMover>().enabled = false;
        collision.gameObject.GetComponent<EnemyAI>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 50, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        collision.gameObject.GetComponent<AgentMover>().enabled = true;
        collision.gameObject.GetComponent<EnemyAI>().enabled = true;
    }
    void Inactive()
    {
        myanim.Play("Inactive");
    }

    void Active()
    {
        myanim.Play("Active");
    }
}
