using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaTecla : MonoBehaviour
{
    public int escena;
    // Start is called before the first frame update
  

   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            cargarEscena(escena);
        }
    }

    public void cargarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }
}
