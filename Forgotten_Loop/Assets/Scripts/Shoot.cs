using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public bool ModoDisparo = false;
    public float tiempoD = 0;
    public float cadencia = 0.5f;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ModoDisparo == true && Time.time > tiempoD)
        {
            tiempoD = Time.time + cadencia;
            GameObject myBullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(myBullet, 2f);
        }

        if (Input.GetButton("Fire1") && ModoDisparo == false && Time.time > tiempoD)
            
        {
            tiempoD = Time.time + cadencia;
            GameObject myBullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(myBullet, 2f);
        }
    }
}
