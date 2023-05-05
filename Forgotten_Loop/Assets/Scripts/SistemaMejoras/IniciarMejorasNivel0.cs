using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarMejorasNivel0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("daño", 1f);
        PlayerPrefs.SetFloat("vidaMax", 1f);
        PlayerPrefs.SetFloat("cadencia", 1f);
        PlayerPrefs.Save();
    }

}
