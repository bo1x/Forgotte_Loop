using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarMejoras : MonoBehaviour
{
    public float daño;
    public float vidaMax;
    public float cadencia;
   
    // Start is called before the first frame update
    void Start()
    {
        daño = PlayerPrefs.GetFloat("daño", 1f);
        vidaMax = PlayerPrefs.GetFloat("vidaMax", 1f);
        cadencia = PlayerPrefs.GetFloat("cadencia", 1f);
    }


}
