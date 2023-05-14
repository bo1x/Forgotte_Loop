using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reducirVel : MonoBehaviour
{
    public float vel;
 
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       
    }
    public void reducirVelocidad()
    {
        GameObject.Find("Player").GetComponent<Control>().movespeed = GameObject.Find("Player").GetComponent<Control>().movespeed / 2;
    }
    public void VelocidadNormal()
    {
        GameObject.Find("Player").GetComponent<Control>().movespeed = 10;
    }
}
