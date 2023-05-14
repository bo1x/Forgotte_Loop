using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    public GameObject VFX;
    public float daño = 0.5f;

    public float tiempoImnunidad;
    private float tiempoPasado;
    private bool DamageTime = true;

    void Start()
    {
        daño = daño * PlayerPrefs.GetFloat("daño");

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

        if (collision.gameObject.tag == "BossEnemy")
        {
            if (DamageTime)
            {
                DamageTime = false;
                ImpactoBalaBoss(collision);
            }
        }
    }

    void ImpactoBalaBoss(Collider2D collider)
    {
        collider.gameObject.GetComponent<BossHPAndFeedback>().VidaActual -= daño;
        Instantiate(VFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    void ImpactoBala(Collider2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= daño;
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
