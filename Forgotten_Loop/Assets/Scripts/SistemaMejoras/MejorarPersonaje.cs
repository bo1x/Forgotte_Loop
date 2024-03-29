using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorarPersonaje : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject almasPlayer;
    public int Almas;
    public int precioDa�o = 30;
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

    public void mejoraDa�o()
    {
        Almas = almasPlayer.GetComponent<Puntos>().Almas;

        Debug.Log("ComproDa�o");

        if (Almas>=precioDa�o &&  1 == PlayerPrefs.GetFloat("da�o"))
        {
            PlayerPrefs.SetFloat("da�o", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioDa�o;
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
