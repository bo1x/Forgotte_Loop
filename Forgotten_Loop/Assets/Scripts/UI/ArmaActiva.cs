using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaActiva : MonoBehaviour
{
    public GameObject armaActiva1UI;
    public GameObject armaActiva2UI;
    public GameObject armaActiva3UI;

    public int armasActivasNum;
    
    public bool Gun;
    public bool Blue;
    public bool Laser;

    public GameObject TengoArmaGun;
    public GameObject TengoArmaLaser;
    public GameObject TengoArmaRifle;


    void Update()
    {
        armasActivasNum = GameObject.Find("Player").GetComponent<Control>().Armas;
        Gun = GameObject.Find("Player").GetComponent<Control>().Gun;
        Blue = GameObject.Find("Player").GetComponent<Control>().Blue;
        Laser = GameObject.Find("Player").GetComponent<Control>().Laser;
        

        if (armasActivasNum==1 && Gun ==true)
        {
           
            armaActiva1UI.SetActive(true);
            armaActiva2UI.SetActive(false);
            armaActiva3UI.SetActive(false);
        }

        if (Blue == true)
        {
            TengoArmaRifle.SetActive(true);
            armaActiva2UI.SetActive(false);

        }
        if (Blue != true)
        {
            TengoArmaRifle.SetActive(false);
            armaActiva2UI.SetActive(false);
            
        }
        if (armasActivasNum == 2 && Blue  == true)
        {
            TengoArmaRifle.SetActive(true);
            armaActiva1UI.SetActive(false);
            armaActiva2UI.SetActive(true);
            armaActiva3UI.SetActive(false);
            
        }

        if (Laser != true)
        {
            TengoArmaLaser.SetActive(false);
            armaActiva3UI.SetActive(false);
            
        }
        if (Laser == true)
        {
            TengoArmaLaser.SetActive(true);
            armaActiva3UI.SetActive(false);

        }
        if (armasActivasNum == 3 && Laser  == true)
        {
            TengoArmaLaser.SetActive(true);
            armaActiva1UI.SetActive(false);
            armaActiva2UI.SetActive(false);
            armaActiva3UI.SetActive(true);

           
        }
        
    }
}
