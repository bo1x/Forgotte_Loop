using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class controlBarraVida : MonoBehaviour
{
    public float vidaActual;
    public float vidaMax;
    public Image barraHP;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        vidaMax = GameObject.Find("Player").GetComponent<VidaPj>().VidaMaxima;
        vidaActual = GameObject.Find("Player").GetComponent<VidaPj>().VidaActual;
        
       barraHP.fillAmount = vidaActual / vidaMax;
    }
}
