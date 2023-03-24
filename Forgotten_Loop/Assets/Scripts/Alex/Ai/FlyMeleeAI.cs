using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMeleeAI : MonoBehaviour
{
    private GameObject player;
    private GameObject refSpawner;
    public Rigidbody2D myrb;
    private bool jugadorEncontrado;
    public float RangoVisionCircular = 5f;
    public float RangoParaAtaque = 2f;
    public bool DibujarEsfera = true;
    public bool perseguir = true;
    public float velocidadMovimiento = 15f;
    public float velocidadAtaqueCarga = 40f;
    private bool atacando = false;
    private bool direccionPillada = false;
    private Vector2 dir;
    private float tiempo = 0f;
    public float TiempoCargaAtaque = 1f;
    private float tiempoCargando = 0f;
    public float tiempoEnLineaRecta = 1f;

    void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    //He stays away from the player a little bit, when he wants to attack, it charges for half a second before it dashes to bite you.

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

        if (jugadorEncontrado)
        {
            if (atacando)
            {
                tiempo = tiempo + Time.deltaTime;
                if (tiempo > TiempoCargaAtaque)
                {
                    if (!direccionPillada)
                    {
                        //  dir = (this.transform.position - player.transform.position).normalized;
                        dir = (player.transform.position - this.transform.position).normalized;
                        direccionPillada = true;
                    }
                    else
                    {
                        // rb.velocity = new Vector3(0, 10, 0);
                        myrb.velocity = dir * velocidadAtaqueCarga;
                        //transform.Translate(dir * velocidadAtaqueCarga * Time.deltaTime);
                        tiempoCargando = tiempoCargando + Time.deltaTime;
                    }

                    if (tiempoCargando > tiempoEnLineaRecta)
                    {
                        atacando = false;
                        direccionPillada = false;
                        tiempo = 0f;
                        tiempoCargando = 0f;
                    }

                }
            }
            else if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < RangoVisionCircular && perseguir)
            {
                if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < RangoParaAtaque)
                {
                    atacando = true;
                }
                else
                {
                   // myrb.velocity = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * velocidadMovimiento);
                     this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * velocidadMovimiento);
                }
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
