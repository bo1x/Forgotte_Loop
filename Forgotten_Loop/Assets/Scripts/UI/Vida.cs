using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{

    private TextMeshProUGUI texto;
    private GameObject pj;
    private float VidaActual, VidaMax;
    
    void Start()
    {
        texto = GameObject.Find("TextoVida").GetComponent<TextMeshProUGUI>();
        pj = GameObject.Find("Player");
    }

   
    void Update()
    {
        if (pj !=null )
        {
            VidaActual = pj.GetComponent<VidaPj>().VidaActual;
            VidaMax = pj.GetComponent<VidaPj>().VidaMaxima;
        }

        if (texto != null)
        {
            texto.SetText(VidaActual + "/" + VidaMax);
        }

        
    }
}
