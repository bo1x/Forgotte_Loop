using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ImpactoBala(collision);
        }
        
    }

    public void ImpactoBala(Collision2D collision)
    {
        Vector2 dir = (transform.position - GameObject.Find("Player").transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 5, ForceMode2D.Impulse);
        
    }
}
