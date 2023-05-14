using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejoras : MonoBehaviour
{
    public AudioClip sonidoCofre;
    public AudioSource src;
    public GameObject Alma;
    public GameObject Pocion;
    public GameObject ArmaBlue;
    public GameObject ArmaLaser;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("cerrao");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            
           // sonidoCofreWapardo();

            if (col.gameObject.GetComponent<Control>().Blue == false)
            {
                Instantiate(ArmaBlue, new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0), transform.rotation);
            }
            else if(col.gameObject.GetComponent<Control>().Laser == false)
            {
                Instantiate(ArmaLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0), transform.rotation);
            }
            else
            {
                if (Random.Range(0, 10) > 3)
                {
                    Instantiate(Pocion, new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0), transform.rotation);
                }
                else
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(Alma, new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0), transform.rotation);
                    }
                }
            }

            anim.Play("Abrir");
            GetComponent<Collider2D>().enabled = false;
            //PlayAnimWaparda
            Destroy(this.gameObject, 3f);

        }
    }

    public void sonidoCofreWapardo()
    {
        src.clip = sonidoCofre;
        src.Play();

    }

    public void abierto()
    {
        anim.Play("abierto");
    }

}
