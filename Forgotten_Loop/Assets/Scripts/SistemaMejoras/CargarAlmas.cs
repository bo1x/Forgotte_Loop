using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CargarAlmas : MonoBehaviour
{
    private GameObject canvas;
    private TextMeshProUGUI textoAlmas;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        textoAlmas = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        canvas = GameObject.Find("Canvas");
        textoAlmas = GetComponent<TextMeshProUGUI>();
        num = canvas.GetComponent<Puntos>().Almas;
        textoAlmas.text = num.ToString();

        

    }
}
