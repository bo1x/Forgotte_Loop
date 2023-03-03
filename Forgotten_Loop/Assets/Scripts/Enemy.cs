using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 5;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Bullet"))
        {
            hp--;
            if (hp==0)
            {
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
           // Destroy(collider.gameObject);
            //Destroy(gameObject);
        }

        
    }
}
