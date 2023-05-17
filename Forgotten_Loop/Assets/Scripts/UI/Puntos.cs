using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puntos : MonoBehaviour
{
    public Text TextoPuntos;
    public int Almas = 0;
    // Start is called before the first frame update
    void Start()
    {
        Almas = (int)PlayerPrefs.GetFloat("almas");
    }

    // Update is called once per frame
    void Update()
    {
        TextoPuntos.text = Almas.ToString();
    }
}
