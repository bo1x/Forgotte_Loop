using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    public GameObject VFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Walls")
        {
            Instantiate(VFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {

            ImpactoBala(collision);
        }
    }

    void ImpactoBala(Collision2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= 1;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
