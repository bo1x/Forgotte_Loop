using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorCanvas : MonoBehaviour
{

    public bool AbroTienda = false;
    public bool AbroPausa = false;

    public GameObject HUD;
    public GameObject PAUSA;
    public GameObject TIENDA;

 
    void Update()
    {
        Debug.Log("TIENDA" + AbroTienda);
        Debug.Log("Pausa" + AbroPausa);

        if (AbroTienda == false && AbroPausa == false)
        {
            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }
            HUD.SetActive(true);
            PAUSA.SetActive(false);
            TIENDA.SetActive(false);

            Cursor.visible = false;
        }
        if (AbroTienda == true && AbroPausa == false)
        {
            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }
            HUD.SetActive(false);
            PAUSA.SetActive(false);
            TIENDA.SetActive(true);

            Cursor.visible = true;
        }
        if (AbroTienda == true && AbroPausa == true)
        {
            if (Time.timeScale>0)
            {
                Time.timeScale = 0;
            }
            HUD.SetActive(false);
            PAUSA.SetActive(true);
            TIENDA.SetActive(false);

            Cursor.visible = true;
        }
        if (AbroTienda == false && AbroPausa == true)
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
            }
            HUD.SetActive(false);
            PAUSA.SetActive(true);
            TIENDA.SetActive(false);

            Cursor.visible = true;
        }
    }

    public void pausa()
    {
        Time.timeScale = 0;

    }

    public void Resume()
    {
        AbroPausa = false;
    }


    public void AMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuInicio");

    }
    public void exit()
    {
        Application.Quit();
    }
}
