using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMeleeAI : MonoBehaviour
{
    private GameObject player;
    public float RangoVisionCircular = 5f;
    public float RangoParaAtaque = 2f;
    public float TiempoCargaAtaque = 0.5f;
    public bool DibujarEsfera = true;
    public bool perseguir = true;
    public float velocidadMovimiento = 15f;
    private bool atacando = false;
    private float tiempo = 0f;

    void Awake()
    {
        player = GameObject.Find("Player");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    //He stays away from the player a little bit, when he wants to attack, it charges for half a second before it dashes to bite you.

    // Update is called once per frame
    void Update()
    {
        if (atacando)
        {
            tiempo = tiempo + Time.deltaTime;
            if (tiempo > TiempoCargaAtaque)
            {
                //Carga Ataque en vector direccion hacia el jugador
            }
        }
        else if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < RangoVisionCircular && perseguir)
        {
            if(Vector3.Distance(this.gameObject.transform.position, player.transform.position) < RangoParaAtaque)
            {
                atacando = true;
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * velocidadMovimiento);
            }
        }
    }

    void OnDrawGizmos()
    {
        player = GameObject.Find("Player");

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
        Gizmos.color = Color.green;

    }
}
