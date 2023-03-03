using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

     void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
   
}
