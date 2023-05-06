using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnseñarIconoInteractuar : MonoBehaviour
{
    float rangoDetecion = 15f;
    GameObject player;
    GameObject icono;
    GameObject canvasMejoras;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        icono = this.transform.Find("Icono").gameObject;
        canvasMejoras = this.transform.Find("canvasHijo").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (detectarPlayer(rangoDetecion))
        {
            icono.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T) && !canvasMejoras.activeInHierarchy)
            {
                canvasMejoras.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.T) && canvasMejoras.activeInHierarchy)
            {
                canvasMejoras.SetActive(false);
            }
        }
        else
        {
            icono.SetActive(false);
            canvasMejoras.SetActive(false);
        }
        
    }

    bool detectarPlayer(float rangoD)
    {
        if (Vector3.Distance(player.transform.position, transform.position) < rangoD)
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
}
