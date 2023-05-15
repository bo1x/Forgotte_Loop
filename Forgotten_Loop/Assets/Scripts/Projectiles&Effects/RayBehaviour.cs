using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour : MonoBehaviour
{

    public float tiempoImnunidad = 0.5f;
    private float tiempoPasado;
    private bool DamageTime = true;

    public float dmg = 0.2f;

    public GameObject Player;
    public GameObject PuntoDisparo;
    void Start()
    {
        dmg = 0.2f;
        transform.parent = null;
        Player = GameObject.Find("Player");
        transform.right = ((Vector2)Player.transform.position - (Vector2)transform.position).normalized;
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        tiempoPasado = tiempoPasado + Time.deltaTime;
        if (tiempoPasado > tiempoImnunidad)
        {
            DamageTime = true;
            tiempoPasado = 0;

        }

        if (PuntoDisparo)
        {
            this.transform.position = PuntoDisparo.transform.position;
        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (DamageTime)
            {
                DamageTime = false;
                StartCoroutine(ImpactoBala(collision));
            }
        }

        
    }

    public IEnumerator ImpactoBala(Collider2D collision)
    {
        //Instanciar Humo o particulas
        Player.GetComponent<VidaPj>().VidaActual = Player.GetComponent<VidaPj>().VidaActual - dmg;
        Vector2 dir = (transform.position - Player.transform.position).normalized;
        Player.GetComponent<Control>().enabled = false;
        Player.GetComponent<Rigidbody2D>().AddForce(-dir * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        Player.GetComponent<Control>().enabled = true;
    }

}
