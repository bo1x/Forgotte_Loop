using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingEyeAgent : MonoBehaviour
{

    //El script que mueve al personaje
    private AgentMover agentMover;

    //Inputs para movimiento y raton
    private Vector2 pointerInput, movementInput;

    //Propiedades que reciben el input del enemigo y el puntero para saber la posicion del player y poder apuntar
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    //Prefab Rayo Ojo
    public GameObject BeamCue;
    public GameObject Beam;

    public Transform BeamPoint;

    public bool Attacked = false;

    private void Update()
    {
        //El update actualiza el movimiento del enemigo
        agentMover.MovementInput = MovementInput;

    }

    //Metodo de ataque
    public void attack()
    {
        //Cambiar Attack Distance en EnemyAI del enemigo para alternar la distancia a la que comienza a disparar
        //Lo mismo para el delay de ataque
        if (!Attacked)
        {
            StartCoroutine("Cue");
        }
    }

    //En el start recibe los componentes necesarios
    private void Start()
    {
        agentMover = GetComponent<AgentMover>();
    }

    public IEnumerator Cue()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<AgentMover>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Attacked = true;
        GameObject Player = GameObject.Find("Player");
        Quaternion RotatePlayer = Quaternion.RotateTowards(transform.rotation, Player.transform.rotation, 360);
        Instantiate(BeamCue, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        Instantiate(Beam, BeamPoint);
        Attacked = false;
        yield return new WaitForSeconds(3f);
        GetComponent<EnemyAI>().enabled = true;
        GetComponent<AgentMover>().enabled = true;
    }
   
}
