using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnseñarIconoInteractuar : MonoBehaviour
{
    float rangoDetecion = 2.5f;
    
    GameObject player;
    GameObject icono;

    public bool enseñoIcono;

    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        icono = transform.Find("Icono").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        canvas = GameObject.Find("Canvas");
        icono = transform.Find("Icono").gameObject;
        
        if (detectarPlayer(rangoDetecion))
        {
            icono.SetActive(true);
            enseñoIcono = true;
        }
        else
        {
            icono.SetActive(false);
            enseñoIcono = false;
        }

        if (Input.GetKeyDown(KeyCode.T) && enseñoIcono == true && canvas.GetComponent<GestorCanvas>().AbroTienda == false)
        {
            canvas.GetComponent<GestorCanvas>().AbroTienda = true;
        }
        else if(Input.GetKeyDown(KeyCode.T) && canvas.GetComponent<GestorCanvas>().AbroTienda == true || enseñoIcono == false)
        {
            
            canvas.GetComponent<GestorCanvas>().AbroTienda = false;
        }
        
    }

    bool detectarPlayer(float rangoD)
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
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
