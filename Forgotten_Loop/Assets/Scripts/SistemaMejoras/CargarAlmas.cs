using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CargarAlmas : MonoBehaviour
{
    private GameObject player;
    private TextMeshProUGUI textoAlmas;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        textoAlmas = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        num = player.GetComponent<parseAlmas>().almas - player.GetComponent<parseAlmas>().restaAlmas;
        textoAlmas.text = num.ToString();

        

    }
}
