using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCamera : MonoBehaviour
{
    [SerializeField] Camera camInfo;
    [SerializeField] Transform player;
    [SerializeField] float threshold;


    //Este script calcula un punto medio entre el raton y el jugador
    //El threshold limita la distancia maxima entre estos
    //Se usa para limitar el movimiento de la camara 
    /*Util https://www.youtube.com/watch?v=LFe017d-S58 */

    void Update()
    {
        Vector3 mousePos = camInfo.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
        Debug.Log(targetPos.ToString());
        Debug.Log("Mouse pos "+mousePos.ToString());

    }
}
