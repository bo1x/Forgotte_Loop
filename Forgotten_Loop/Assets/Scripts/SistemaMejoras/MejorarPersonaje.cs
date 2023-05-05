using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorarPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mejoraDaño()
    {
        PlayerPrefs.SetFloat("daño", 2f);
        PlayerPrefs.Save();
    }
    void mejoraVida()
    {
        PlayerPrefs.SetFloat("vidaMax", 2f);
        PlayerPrefs.Save();
    }
    void mejoraCadencia()
    {
        PlayerPrefs.SetFloat("cadencia", 2f);
        PlayerPrefs.Save();
    }
}
