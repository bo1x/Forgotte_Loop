using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonidoconfigmute : MonoBehaviour
{
    public string nombreEscena;
    private Scene Escena;
    public GameObject sonido;

    
    // Start is called before the first frame update
    void Start()
    {
        Escena = SceneManager.GetActiveScene();
        nombreEscena = Escena.name;
        if (nombreEscena == "HubPrincipal")
        {
            sonido.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
