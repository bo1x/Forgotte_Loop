using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarMejorasCanvas : MonoBehaviour
{
    private TextMeshProUGUI panelmejoras;
    private float daño;
    private float vidaMax;
    private float cadencia;


    private GameObject almasPlayer;



    // Start is called before the first frame update
    void Start()
    {
        panelmejoras = GameObject.Find("Stats").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        MostrarMejoras();
    }



    void MostrarMejoras()
    {
        daño = PlayerPrefs.GetFloat("daño");
        vidaMax = PlayerPrefs.GetFloat("vidaMax");
        cadencia = PlayerPrefs.GetFloat("cadencia");
        panelmejoras.SetText("Attack Lvl : {0} \nMaxHP Lvl: {1} \nFire Rate Lvl: {2}", daño, vidaMax, cadencia);
    }

   
}
