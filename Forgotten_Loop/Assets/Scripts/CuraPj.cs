using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraPj : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<VidaPj>().VidaActual = col.gameObject.GetComponent<VidaPj>().VidaMaxima;
            Destroy(this.gameObject);
        }
    }
}
