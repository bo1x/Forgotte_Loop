using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speedBullet;
    public GameObject Player;

    public GameObject VFX;

    void Start()
    {
        transform.parent = null;
        Player = GameObject.Find("Player");
        transform.right = ((Vector2)Player.transform.position - (Vector2)transform.position).normalized;
        Destroy(gameObject, 5);
    }


    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right *speedBullet;
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
        Instantiate(VFX, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Player.GetComponent<VidaPj>().VidaActual--;
        Vector2 dir = (transform.position - Player.transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 20, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        collision.gameObject.GetComponent<Control>().enabled = true;
        Destroy(this.gameObject);
    }

}
