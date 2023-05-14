using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject canvasHud;
    public bool EstoyEnMenuPausa = false;

   void Start()
    {
       menuPausa = GameObject.Find("MenuPausa");
       menuPausa.SetActive(false);
       canvasHud = GameObject.Find("Canvas");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("CambioCanvas");
            if (EstoyEnMenuPausa==true)
            {
                Debug.Log("sALGO MENU");
                Resume();
            }
            else
            {
                Debug.Log("ENTRO MENU");
                pausa();
            }
         }
    }
   
    public void pausa()
    {
        canvasHud.SetActive(false);
        menuPausa.SetActive(true);
        EstoyEnMenuPausa = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Debug.Log(menuPausa.ToString());

        menuPausa.SetActive(false);
        canvasHud.SetActive(true);
        Debug.Log("CanvasHUD " + canvasHud);
        EstoyEnMenuPausa = false;
       
    }

    public void AMenuPrincipal()
    {
        SceneManager.LoadScene("MenuInicio");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Esc()
    {
        Input.GetKeyDown(KeyCode.Escape);
    }
}
