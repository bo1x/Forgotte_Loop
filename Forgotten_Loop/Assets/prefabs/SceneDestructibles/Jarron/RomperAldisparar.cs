using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperAldisparar : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            anim.Play("destruccion");
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            anim.Play("destruccion");
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void pasarAroto()
    {
        anim.Play("roto");
    }
}
