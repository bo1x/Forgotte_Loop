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

    public GameObject dañoimagen;
    public GameObject hpimagen;
    public GameObject cadenciaimagen;

    // Start is called before the first frame update
    void Start()
    {
        panelmejoras = GameObject.Find("Stats").GetComponent<TextMeshProUGUI>();
        MostrarMejoras();
    }



    void MostrarMejoras()
    {
        daño = PlayerPrefs.GetFloat("daño", 1f);
        vidaMax = PlayerPrefs.GetFloat("vidaMax", 1f);
        cadencia = PlayerPrefs.GetFloat("cadencia", 1f);
        panelmejoras.SetText("Attack Lvl : {0} \nMaxHP Lvl: {1} \nFire Rate Lvl: {2}", daño, vidaMax, cadencia);
    }

    public void UpgradeDaño()
    {
        PlayerPrefs.SetFloat("daño", 2f);
        PlayerPrefs.Save();
        dañoimagen.SetActive(true);
        MostrarMejoras();
    }

    public void UpgradeCadencia()
    {
        PlayerPrefs.SetFloat("cadencia", 2f);
        PlayerPrefs.Save();
        cadenciaimagen.SetActive(true);
        MostrarMejoras();

    }

    public void UpgradeVida()
    {
        PlayerPrefs.SetFloat("vidaMax", 2f);
        PlayerPrefs.Save();
        hpimagen.SetActive(true);
        MostrarMejoras();

    }
}
