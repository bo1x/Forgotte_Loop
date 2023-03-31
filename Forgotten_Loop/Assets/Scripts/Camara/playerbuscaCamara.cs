using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerbuscaCamara : MonoBehaviour
{
    private bool playerEncontrado;
    private bool camaraFijada;
    private GameObject player;
    private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {

         vcam = GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Player") != null && playerEncontrado == false)
        {
            Debug.Log("Encontrado");
            player = GameObject.Find("Player");
            playerEncontrado = true;
        }
        if (playerEncontrado && camaraFijada == false)
        {
           // vcam.LookAt = player.transform;
            vcam.Follow = player.transform;
            camaraFijada = true;
            Debug.Log("Camara Fijada");
        }
       
    }
}
