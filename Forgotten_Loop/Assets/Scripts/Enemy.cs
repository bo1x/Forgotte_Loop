using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 5;
    public GameObject Canvas;

     void Start()
    {
       Canvas = GameObject.Find("Canvas");

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Bullet"))
        {
            hp--;
            if (hp==0)
            {
                Canvas.GetComponent<Puntos>().Almas = Canvas.GetComponent<Puntos>().Almas + 1;
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
           // Destroy(collider.gameObject);
            //Destroy(gameObject);
        }

        
    }
}
