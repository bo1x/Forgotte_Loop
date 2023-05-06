using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{

    private TextMeshProUGUI texto;
    private GameObject pj;
    private int VidaActual, VidaMax;
    
    void Start()
    {
        texto = GameObject.Find("TextoVida").GetComponent<TextMeshProUGUI>();
        pj = GameObject.Find("Player");
    }

   
    void Update()
    {
        VidaActual =  pj.GetComponent<VidaPj>().VidaActual;
        VidaMax = pj.GetComponent<VidaPj>().VidaMaxima;

        texto.SetText(VidaActual + "/" + VidaMax);
    }
}
