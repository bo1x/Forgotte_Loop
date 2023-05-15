using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pausa : MonoBehaviour
{

    public GameObject canvas;

   void Start()
   {
        canvas = GameObject.Find("Canvas");
   }

    public void PauseMenu(InputAction.CallbackContext context)
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
