using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{

    public GameObject canvas;

   void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.GetComponent<GestorCanvas>().AbroPausa == true)
            {
                canvas.GetComponent<GestorCanvas>().AbroPausa = false;
            }
            else
            {
                canvas.GetComponent<GestorCanvas>().AbroPausa = true;
            }
         }
    }
   
    
}
