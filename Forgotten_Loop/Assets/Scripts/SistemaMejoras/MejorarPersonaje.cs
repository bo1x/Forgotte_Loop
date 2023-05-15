using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorarPersonaje : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject almasPlayer;
    public int Almas;
    public int precioDaño = 30;
    public int precioVida = 20;
    public int precioCadencia = 10;
    void Start()
    {
        almasPlayer = GameObject.Find("Canvas");
        Almas = almasPlayer.GetComponent<Puntos>().Almas;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mejoraDaño()
    {
        Almas = almasPlayer.GetComponent<Puntos>().Almas;

        Debug.Log("ComproDaño");

        if (Almas>=precioDaño &&  1 == PlayerPrefs.GetFloat("daño"))
        {
            PlayerPrefs.SetFloat("daño", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioDaño;
        }
    }
    public void mejoraVida()
    {
        Almas = almasPlayer.GetComponent<Puntos>().Almas;

        Debug.Log("CompraVida");


        if (Almas >= precioVida && 1 == PlayerPrefs.GetFloat("vidaMax"))
        {
            PlayerPrefs.SetFloat("vidaMax", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioVida;
        }
    }
    public void mejoraCadencia()
    {
        Debug.Log("ComproCadencia");

        Almas = almasPlayer.GetComponent<Puntos>().Almas;
        if (Almas >= precioCadencia && 1 == PlayerPrefs.GetFloat("cadencia"))
        {
            PlayerPrefs.SetFloat("cadencia", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioCadencia;
        }
    }
}
