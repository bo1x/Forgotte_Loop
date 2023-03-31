using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject Player;

    public Vector2 position;

    void Start()
    {
        transform.parent = null;
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        position = Player.GetComponent<Control>().PositionMouse();
        transform.right = (position - (Vector2)transform.position).normalized;
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if(collision.gameObject.name == "Walls")
        {
            ImpactoBala();
        }

        if(collision.gameObject.tag == "Enemy")
        {
            // collision.gameObject.GetComponent<Scriptquetengasuvida>().SuVidaVariable-1
            ImpactoBala();
        }
    }

    void ImpactoBala()
    {
        //Instanciar Humo o particulas
        Destroy(this.gameObject);
    }

}
