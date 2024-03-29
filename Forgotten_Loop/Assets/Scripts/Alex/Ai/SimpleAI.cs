using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    private GameObject player;
    private GameObject refSpawner;
    private bool jugadorEncontrado;
    public float RangoVisionCircular = 5f;
    public bool DibujarEsfera = true;
    public bool perseguir = true;
    public float velocidadMovimiento = 5f;

    // Start is called before the first frame update

    void Awake()
    {
       
    }
    void Start()
    {
        jugadorEncontrado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SpawnerPlayer"))
        {
            refSpawner = GameObject.Find("SpawnerPlayer");
            if (refSpawner.GetComponent<SpawnJugador>().jugadoExiste)
            {
                player = GameObject.Find("testplayer(Clone)");
                jugadorEncontrado = true;
            }
             
        }
        //Obtienes distancia entre 2 puntos
        //Debug.Log(Vector3.Distance(this.gameObject.transform.position, player.transform.position));
        if (jugadorEncontrado) {
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < RangoVisionCircular && perseguir)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * velocidadMovimiento);
            }
        }
       
      

    }

    void OnDrawGizmos()
    {

        if (jugadorEncontrado)
        {
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < RangoVisionCircular && perseguir)
            {
                Gizmos.color = Color.red;
            }
            else { Gizmos.color = Color.green; }
            // Draw a yellow sphere at the transform's position
            if (DibujarEsfera)
            {
                Gizmos.DrawWireSphere(this.gameObject.transform.position, RangoVisionCircular);
            }
        }
        Gizmos.color = Color.green;
      
    }
}
