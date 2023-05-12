using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnseñarIconoInteractuar : MonoBehaviour
{
    float rangoDetecion = 2.5f;
    GameObject canvasUI;
    GameObject player;
    GameObject icono;
    GameObject canvasMejoras;
    // Start is called before the first frame update
    void Start()
    {
        canvasUI = GameObject.Find("Canvas");
        player = GameObject.Find("Player");
        icono = this.transform.Find("Icono").gameObject;
        canvasMejoras = this.transform.Find("canvasHijo").gameObject;
        canvasMejoras.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (detectarPlayer(rangoDetecion))
        {
            icono.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T) && !canvasMejoras.activeInHierarchy)
            {
                Debug.Log("ACTIVO");
                canvasUI.SetActive(false);
                canvasMejoras.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.T) && canvasMejoras.activeInHierarchy)
            {
                Debug.Log("DESACTIVO");
                canvasMejoras.SetActive(false);
                canvasUI.SetActive(true);

            }

        }
        else
        {
            icono.SetActive(false);
            canvasMejoras.SetActive(false);
           // canvasUI.SetActive(true);

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
