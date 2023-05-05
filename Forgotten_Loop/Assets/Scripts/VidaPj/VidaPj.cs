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
    private GameObject Vcam;
    

    // Start is called before the first frame update
    void Start()
    {
        //VidaMaxima = VidaMaxima * (int)PlayerPrefs.GetFloat("vidaMax");
        VidaActual = VidaMaxima;
        canvasitofachero = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Vida" + VidaMaxima);
        tiempoPasado = tiempoPasado + Time.deltaTime;

        canvasitofachero.GetComponent<Vida>().vida = VidaActual;

        if (VidaActual <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            if (tiempoPasado>tiempoImnunidad)
            {
                VidaActual = VidaActual - 1;
                tiempoPasado = 0;
                Vcam = GameObject.Find("CM vcam1");
                Vcam.GetComponent<cameraShake>().Shake(0.3f, 0.5f, 0.3f);                      
            }
        }

    }

 }

