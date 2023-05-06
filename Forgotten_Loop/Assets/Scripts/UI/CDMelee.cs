using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CDMelee : MonoBehaviour
{
    
    public GameObject cdArmaMelee;
    private float contador;
    public bool heGolpeado = false;
    public bool contando = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
      heGolpeado = GameObject.Find("Player").GetComponent<Control>().MeleeCooldown;

        Debug.Log(contador);
        Debug.Log(contando);
        if (heGolpeado == true)
        {
            contando = true;            
        }

        if (contando)
        {
            contador = contador + Time.deltaTime;
            cdArmaMelee.GetComponent<Image>().fillAmount = contador / 10f;
        }
        if (contador >= 10.2f)
        {
            Debug.Log("fin");
           // contador = 0.0f;
            contando = false;
            
        }
        if (!contando)
        {
            contador = 0f;
            cdArmaMelee.GetComponent<Image>().fillAmount = 1.0f;
        }

        }
       
    }
