using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnseñarIconoInteractuar : MonoBehaviour
{
    float rangoDetecion = 2.5f;
    
    GameObject player;
    GameObject icono;

    public bool enseñoIcono;


    public GameObject canvas;
    
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        icono = transform.Find("Icono").gameObject;
    }
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

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && enseñoIcono == true && canvas.GetComponent<GestorCanvas>().AbroTienda == false)
        {
            canvas.GetComponent<GestorCanvas>().AbroTienda = true;
        }
        else if (context.performed && canvas.GetComponent<GestorCanvas>().AbroTienda == true || enseñoIcono == false)
        {

            canvas.GetComponent<GestorCanvas>().AbroTienda = false;
        }
    }
}
