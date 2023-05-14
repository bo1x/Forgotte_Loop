using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    public GameObject VFX;
    public int da�o = 1;

    public float tiempoImnunidad;
    private float tiempoPasado;
    private bool DamageTime = true;

    void Start()
    {
        da�o = da�o * (int)PlayerPrefs.GetFloat("da�o");

    }

    private void Update()
    {

        tiempoPasado = tiempoPasado + Time.deltaTime;
        if (tiempoPasado > tiempoImnunidad)
        {
            DamageTime = true;
            tiempoPasado = 0;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (DamageTime)
            {
                DamageTime = false;
                ImpactoBala(collision);
            }
        }
    }

    void ImpactoBala(Collider2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= da�o;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
    }

    public void reducirVelocidad()
    {
        GameObject.Find("Player").GetComponent<Control>().movespeed = GameObject.Find("Player").GetComponent<Control>().movespeed / 2;
    }
    public void VelocidadNormal()
    {
        GameObject.Find("Player").GetComponent<Control>().movespeed = 10;
    }
}
