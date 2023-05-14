using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperAldisparar : MonoBehaviour
{
    private Animator anim;
    public AudioSource src;
    public AudioClip romperJarron;

    public GameObject alma;

    
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

            if (Random.Range(1,10)<2)
            {
                int numeroAleatorio = Random.Range(1, 4);

                for (int i = 0; i < numeroAleatorio; i++)
                {
                    Instantiate(alma, new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0), transform.rotation);
                }
            }
         
            sonidoJarronRompido();
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            anim.Play("destruccion");
            GetComponent<Collider2D>().enabled = false;
            sonidoJarronRompido();
        }
    }

    void pasarAroto()
    {
        anim.Play("roto");
    }
    public void sonidoJarronRompido()
    {
        src.clip = romperJarron;
        src.Play();

    }
}
