using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackMeleeAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ImpactoBala(collision);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BossProjectile")
        {
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator ImpactoBala(Collision2D collision)
    {
        Vector2 dir = (transform.position - collision.transform.position).normalized;
        collision.gameObject.GetComponent<AgentMover>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 20, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        collision.gameObject.GetComponent<AgentMover>().enabled = true;

    }
}
