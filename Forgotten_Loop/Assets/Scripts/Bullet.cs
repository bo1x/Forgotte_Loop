using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject Player;

    public Vector2 position;

    public GameObject VFX;
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
            Instantiate(VFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
           
            ImpactoBala(collision);
        }
    }

    void ImpactoBala(Collision2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= 1;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir*10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
