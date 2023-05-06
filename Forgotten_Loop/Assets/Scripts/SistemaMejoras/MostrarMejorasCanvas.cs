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

    // Start is called before the first frame update
    void Start()
    {
        panelmejoras = GameObject.Find("Stats").GetComponent<TextMeshProUGUI>();
        MostrarMejoras();
    }



    void MostrarMejoras()
    {
        da�o = PlayerPrefs.GetFloat("da�o", 1f);
        vidaMax = PlayerPrefs.GetFloat("vidaMax", 1f);
        cadencia = PlayerPrefs.GetFloat("cadencia", 1f);
        panelmejoras.SetText("Da�o: {0}  VidaMaxima: {1}  Cadencia: {2}", da�o, vidaMax, cadencia);
    }

    public void UpgradeDa�o()
    {
        PlayerPrefs.SetFloat("da�o", 2f);
        PlayerPrefs.Save();
        MostrarMejoras();
    }

    public void UpgradeCadencia()
    {
        PlayerPrefs.SetFloat("cadencia", 2f);
        PlayerPrefs.Save();
        MostrarMejoras();

    }

    public void UpgradeVida()
    {
        PlayerPrefs.SetFloat("vidaMax", 2f);
        PlayerPrefs.Save();
        MostrarMejoras();

    }
}
