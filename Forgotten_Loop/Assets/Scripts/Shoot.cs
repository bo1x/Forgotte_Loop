using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject myBullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(myBullet, 2f);
        }
    }
}
