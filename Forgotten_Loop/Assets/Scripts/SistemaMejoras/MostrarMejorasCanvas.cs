using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarMejorasCanvas : MonoBehaviour
{
    private TextMeshProUGUI panelmejoras;
    private float da�o;
    private float vidaMax;
    private float cadencia;

    public GameObject da�oimagen;
    public GameObject hpimagen;
    public GameObject cadenciaimagen;

    private GameObject almasPlayer;
    public int AlmasCopia;
    public int precioDa�o = 30;
    public int precioVida = 20;
    public int precioCadencia = 10;


    // Start is called before the first frame update
    void Start()
    {

        almasPlayer = GameObject.Find("Player");
        AlmasCopia = almasPlayer.GetComponent<parseAlmas>().almas;
        panelmejoras = GameObject.Find("Stats").GetComponent<TextMeshProUGUI>();
        MostrarMejoras();
    }



    void MostrarMejoras()
    {
        da�o = PlayerPrefs.GetFloat("da�o", 1f);
        vidaMax = PlayerPrefs.GetFloat("vidaMax", 1f);
        cadencia = PlayerPrefs.GetFloat("cadencia", 1f);
        panelmejoras.SetText("Attack Lvl : {0} \nMaxHP Lvl: {1} \nFire Rate Lvl: {2}", da�o, vidaMax, cadencia);
    }

    public void UpgradeDa�o()
    {
        AlmasCopia = almasPlayer.GetComponent<parseAlmas>().almas;
        if (AlmasCopia >= precioDa�o && 1 == PlayerPrefs.GetFloat("da�o"))
        {
            PlayerPrefs.SetFloat("da�o", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<parseAlmas>().restaAlmas += precioDa�o;
            da�oimagen.SetActive(true);
            MostrarMejoras();
        }



    
    }

    public void UpgradeCadencia()
    {

        AlmasCopia = almasPlayer.GetComponent<parseAlmas>().almas;
        if (AlmasCopia >= precioCadencia && 1 == PlayerPrefs.GetFloat("cadencia"))
        {
            PlayerPrefs.SetFloat("cadencia", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<parseAlmas>().restaAlmas += precioCadencia;
            cadenciaimagen.SetActive(true);
            MostrarMejoras();
        }


    }

    public void UpgradeVida()
    {
        AlmasCopia = almasPlayer.GetComponent<parseAlmas>().almas;
        if (AlmasCopia >= precioVida && 1 == PlayerPrefs.GetFloat("vidaMax"))
        {
            PlayerPrefs.SetFloat("vidaMax", 2f);
            PlayerPrefs.Save();
            almasPlayer.GetComponent<parseAlmas>().restaAlmas += precioVida;
            hpimagen.SetActive(true);
            MostrarMejoras();
        }

    }
}
