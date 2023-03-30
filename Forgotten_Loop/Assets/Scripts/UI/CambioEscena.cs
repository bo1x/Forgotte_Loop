using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
  //  public int escena = 0;
    // Start is called before the first frame update


    public void cargarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }
}
