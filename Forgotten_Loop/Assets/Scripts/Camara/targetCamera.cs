using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCamera : MonoBehaviour
{
    [SerializeField] Camera camInfo;
    private bool camEncontrada = false;
    [SerializeField] Transform player;
    private bool playerEncontrado = false;
    [SerializeField] float threshold;


    //Este script calcula un punto medio entre el raton y el jugador
    //El threshold limita la distancia maxima entre estos
    //Se usa para limitar el movimiento de la camara 
    /*Util https://www.youtube.com/watch?v=LFe017d-S58 */
    void Start()
    {
        
    }
    void Update()
    {

        if (camInfo == null)
        {
            camInfo = Camera.main;
            camEncontrada = true;
        }
       if ( player == null)
        {
            player = GameObject.Find("Player").transform;
            playerEncontrado = true;
        }

        

        if (camEncontrada && playerEncontrado)
        {
            Vector3 mousePos = camInfo.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPos = (player.position + mousePos) / 2f;

            targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
            targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

            this.transform.position = targetPos;
          //  Debug.Log(targetPos.ToString());
          //  Debug.Log("Mouse pos " + mousePos.ToString());
        }
        
        

    }
}
