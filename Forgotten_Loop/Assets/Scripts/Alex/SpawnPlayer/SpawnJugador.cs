using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJugador : MonoBehaviour
{
    public bool jugadoExiste = false;
    public GameObject prefabPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (!jugadoExiste)
        {
            Instantiate(prefabPlayer, transform.position, Quaternion.identity);
            jugadoExiste = true;
        }
        
        
    }

}
