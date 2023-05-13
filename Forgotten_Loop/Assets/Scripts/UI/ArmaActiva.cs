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
   
    void Update()
    {
        armasActivasNum = GameObject.Find("Player").GetComponent<Control>().Armas;
        Gun = GameObject.Find("Player").GetComponent<Control>().Gun;
        Laser= GameObject.Find("Player").GetComponent<Control>().Laser;
        Blue = GameObject.Find("Player").GetComponent<Control>().Blue;

        if (armasActivasNum==1 && Gun ==true)
        {
           
            armaActiva1UI.SetActive(true);
            armaActiva2UI.SetActive(false);
            armaActiva3UI.SetActive(false);
        }

        if (armasActivasNum == 2 && Blue == true)
        {
            armaActiva1UI.SetActive(false);
            armaActiva2UI.SetActive(true);
            armaActiva3UI.SetActive(false);
        }

        if (armasActivasNum == 3 && Laser ==true)
        {
            armaActiva1UI.SetActive(false);
            armaActiva2UI.SetActive(false);
            armaActiva3UI.SetActive(true);
        }
       
    }
}
