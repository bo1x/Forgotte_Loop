using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkifallenemyDEAD : MonoBehaviour
{
    public GameObject[] enemigos;
    public GameObject ending;
    private int enemigosMuertos;
    private bool ene1, ene2, ene3, ene4, ene5 = true;
    void Start()
    {
        enemigosMuertos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemigos.Length; i++)
        {
            if(enemigos[0] == null && ene1)
            {
                enemigosMuertos = enemigosMuertos + 1;
                ene1 = false;
            }
            if (enemigos[1] == null && ene2)
            {
                enemigosMuertos = enemigosMuertos + 1;
                ene2 = false;
            }
            if (enemigos[2] == null && ene3)
            {
                enemigosMuertos = enemigosMuertos + 1;
                ene2 = false;
            }
            if (enemigos[3] == null && ene4)
            {
                enemigosMuertos = enemigosMuertos + 1;
                ene2 = false;
            }
            if (enemigos[4] == null && ene5)
            {
                enemigosMuertos = enemigosMuertos + 1;
                ene2 = false;
            }
        }

        if(enemigosMuertos == enemigos.Length)
        {
            Debug.Log("Muertos" + enemigosMuertos);
            Debug.Log("TODOS" + enemigos.Length);
            Debug.Log("TodosMuertos");
            ending.SetActive(true);
        }
    }
}
