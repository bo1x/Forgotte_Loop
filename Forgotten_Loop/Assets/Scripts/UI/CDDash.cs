using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CDDash : MonoBehaviour
{
    
    public GameObject cdDash;
    private float contador;
    public bool heDasheado = false;
    public bool contando = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
      heDasheado = GameObject.Find("Player").GetComponent<Control>().IsDashing;


        if (heDasheado == true)
        {
            contando = true;            
        }

        if (contando)
        {
            contador = contador + Time.deltaTime;
            cdDash.GetComponent<Image>().fillAmount = contador / 4f;
        }
        if (contador >= 4.0f)
        {
           
           // contador = 0.0f;
            contando = false;
            
        }
        if (!contando)
        {
            contador = 0f;
            cdDash.GetComponent<Image>().fillAmount = 1.0f;
        }

        }
       
    }
