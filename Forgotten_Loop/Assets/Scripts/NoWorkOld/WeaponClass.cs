using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass : MonoBehaviour
{

    //WeaponClass Gun = new WeaponClass("Gun", 2.0f, 20);
    //Variables
    public string weapon;
    public float attack;
    public int ammo;
    public GameObject bulletPrefab;

    //Constructor

    //Métodos


    private void Update()
    {
        CheckFiring();



    }

    public void CheckFiring()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            Destroy(bullet, 5f);
        }

    }
}
