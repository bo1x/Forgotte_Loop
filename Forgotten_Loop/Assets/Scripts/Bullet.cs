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

    public int daño = 1;
    void Start()
    {
        daño = daño * (int)PlayerPrefs.GetFloat("daño");
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
        /*Collider2D Aim = Physics2D.OverlapCircle(transform.position, 200f);
        if (Aim.tag == "Enemy")
        {
            transform.position = Vector2.MoveTowards(transform.position, Aim.transform.position, speed*500);
        }*/
        
    }

    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 200f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if(collision.gameObject.name == "Walls")
        {
            Instantiate(VFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.name == "Collideable")
        {
            Instantiate(VFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Obstacles")
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
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= daño;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x * -1, dir.y * -1)*10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
