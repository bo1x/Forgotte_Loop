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

    private Vector2 Orientation;

    public int da�o = 1;
    void Start()
    {
        da�o = da�o * (int)PlayerPrefs.GetFloat("da�o");
        transform.parent = null;
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        position = Player.GetComponent<Control>().PositionMouse();
        transform.right = (position - (Vector2)transform.position).normalized;
        Orientation = new Vector2(speed, speed);
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        rb.velocity = transform.right * Orientation;
        /*Collider2D Aim = Physics2D.OverlapCircle(transform.position, 2);
        if (Aim.tag == "Enemy")
        {
            Debug.Log("Matame");
        }*/
        
    }

    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2);
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

        if (collision.gameObject.tag == "BossEnemy")
        {
            ImpactoBalaBoss(collision);
        }
    }

    void ImpactoBala(Collision2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= da�o;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x * -1, dir.y * -1)*10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    void ImpactoBalaBoss(Collision2D collider)
    {
        collider.gameObject.GetComponent<BossHPAndFeedback>().VidaActual -= da�o;
        Instantiate(VFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
