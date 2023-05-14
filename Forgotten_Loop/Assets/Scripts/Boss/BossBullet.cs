using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector2 Direction;

    public GameObject VFX;

    public float Speed;

    private Rigidbody2D myrigi;

    public void OnEnable()
    {
        Invoke("SetOff", 3f);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        myrigi.velocity = Direction * Speed;
    }

    public void ChangeDirection(Vector2 dir)
    {
        Direction = dir;
    }

    private void SetOff()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ImpactoBala(collision));
        }
        if (collision.gameObject.name == "Walls")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(VFX, transform.position, transform.rotation);
        }

        if (collision.gameObject.name == "Collideable")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(VFX, transform.position, transform.rotation);
        }

        if (collision.gameObject.tag == "Obstacles")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(VFX, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Walls")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(VFX, transform.position, transform.rotation);
        }

        if (collision.gameObject.name == "Collideable")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(VFX, transform.position, transform.rotation);
        }

        if (collision.gameObject.tag == "Obstacles")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(VFX, transform.position, transform.rotation);
        }
    }

    public IEnumerator ImpactoBala(Collider2D collision)
    {
        //Instanciar Humo o particulas
        Instantiate(VFX, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GameObject.Find("Player").GetComponent<VidaPj>().VidaActual--;
        Vector2 dir = (transform.position - GameObject.Find("Player").transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 20, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        collision.gameObject.GetComponent<Control>().enabled = true;
        
    }
}
