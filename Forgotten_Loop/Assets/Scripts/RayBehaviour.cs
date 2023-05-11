using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour : MonoBehaviour
{

    public GameObject Player;
    public GameObject PuntoDisparo;
    void Start()
    {
        transform.parent = null;
        Player = GameObject.Find("Player");
        transform.right = ((Vector2)Player.transform.position - (Vector2)transform.position).normalized;
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        if (PuntoDisparo)
        {
            this.transform.position = PuntoDisparo.transform.position;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ImpactoBala(collision));
        }
    }

    public IEnumerator ImpactoBala(Collider2D collision)
    {
        //Instanciar Humo o particulas
        Player.GetComponent<VidaPj>().VidaActual--;
        Vector2 dir = (transform.position - Player.transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        collision.gameObject.GetComponent<Control>().enabled = true;
    }

}
