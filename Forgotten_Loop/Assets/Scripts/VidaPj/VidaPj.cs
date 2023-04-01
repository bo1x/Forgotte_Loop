using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPj : MonoBehaviour
{

    public int VidaActual;
    public int VidaMaxima;
    public float tiempoImnunidad;
    private float tiempoPasado;
    private GameObject canvasitofachero;
    

    // Start is called before the first frame update
    void Start()
    {
        VidaActual = VidaMaxima;
        canvasitofachero = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        tiempoPasado = tiempoPasado + Time.deltaTime;

        canvasitofachero.GetComponent<Vida>().vida = VidaActual;

        if (VidaActual <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            if (tiempoPasado>tiempoImnunidad)
            {
                VidaActual = VidaActual - 1;
                tiempoPasado = 0;

                
            }

        }
    }
}
