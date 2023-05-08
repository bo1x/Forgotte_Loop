using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    public GameObject VFX;
    public int da�o = 1;

    void Start()
    {
        da�o = da�o * (int)PlayerPrefs.GetFloat("da�o");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {

            ImpactoBala(collision);
        }
    }

    void ImpactoBala(Collider2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= da�o;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
        
    }

    
}
