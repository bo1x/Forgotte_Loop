using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarMejoras : MonoBehaviour
{
    public float da�o;
    public float vidaMax;
    public float cadencia;
   
    // Start is called before the first frame update
    void Start()
    {
        da�o = PlayerPrefs.GetFloat("da�o", 1f);
        vidaMax = PlayerPrefs.GetFloat("vidaMax", 1f);
        cadencia = PlayerPrefs.GetFloat("cadencia", 1f);
    }


}
