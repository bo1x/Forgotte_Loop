using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaconesAgent : MonoBehaviour
{

    private Animator myanim;

    //El script que mueve al personaje
    private AgentMover agentMover;

    //Inputs para movimiento y raton
    private Vector2 pointerInput, movementInput;

    //Propiedades que reciben el input del enemigo y el puntero para saber la posicion del player y poder apuntar
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }


    //En el start recibe los componentes necesarios
    private void Start()
    {
        agentMover = GetComponent<AgentMover>();
    }

    private void Update()
    {
        //El update actualiza el movimiento del enemigo
        agentMover.MovementInput = MovementInput;
        myanim = GetComponent<Animator>();
    }

    //Metodo de ataque
    public void attack()
    {
        myanim.Play("Attack");
    }

    public void ActiveMove()
    {
        GameObject.Find("Player").GetComponent<Control>().enabled = true;
    }
    public void BackIdle()
    {
        myanim.Play("IdleMove");
    }
}
