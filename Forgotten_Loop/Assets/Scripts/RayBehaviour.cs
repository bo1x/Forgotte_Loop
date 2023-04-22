using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject Player;

    private Vector2 position;

    void Start()
    {
        transform.parent = null;
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        transform.right = ((Vector2)Player.transform.position - (Vector2)transform.position).normalized;
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(collision.gameObject.name == "Walls")
        {
            ImpactoBala();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ImpactoBala();
        }
    }

    void ImpactoBala()
    {
        //Instanciar Humo o particulas
        Player.GetComponent<VidaPj>().VidaActual--;
        Destroy(this.gameObject);
    }

}
