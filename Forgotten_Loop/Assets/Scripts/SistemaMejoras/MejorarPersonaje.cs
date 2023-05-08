using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorarPersonaje : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject almasPlayer;
    public int Almas;
    public int precioDa�o = 30;
    public int precioVida = 20;
    public int precioCadencia = 10;
    void Start()
    {
        almasPlayer = GameObject.Find("Player");
        Almas = almasPlayer.GetComponent<Puntos>().Almas;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mejoraDa�o()
    {
        Almas = almasPlayer.GetComponent<Puntos>().Almas;
        if (Almas>=precioDa�o &&  1 == PlayerPrefs.GetFloat("da�o"))
        {
            PlayerPrefs.SetFloat("da�o", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioDa�o;
        }
    }
    void mejoraVida()
    {
        Almas = almasPlayer.GetComponent<Puntos>().Almas;
        if (Almas >= precioVida && 1 == PlayerPrefs.GetFloat("vidaMax"))
        {
            PlayerPrefs.SetFloat("vidaMax", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioVida;
        }
    }
    void mejoraCadencia()
    {

        Almas = almasPlayer.GetComponent<Puntos>().Almas;
        if (Almas >= precioVida && 1 == PlayerPrefs.GetFloat("cadencia"))
        {
            PlayerPrefs.SetFloat("cadencia", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<Puntos>().Almas = Almas - precioCadencia;
        }
    }
}
