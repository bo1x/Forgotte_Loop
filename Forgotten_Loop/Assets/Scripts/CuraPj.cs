using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraPj : MonoBehaviour
{
    public AudioClip healingSound;
    public AudioSource src;
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            healingg();

            col.gameObject.GetComponent<VidaPj>().VidaActual = col.gameObject.GetComponent<VidaPj>().VidaMaxima;
            healingg();
            GetComponent<SpriteRenderer>().enabled = false;

            Destroy(this.gameObject,3f);

        }
    }

    public void healingg()
    {
        src.clip = healingSound;
        src.Play();
       
    }
}
