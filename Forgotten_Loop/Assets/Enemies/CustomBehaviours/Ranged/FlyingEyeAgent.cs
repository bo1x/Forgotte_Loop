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
    public GameObject Rayo;

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
        Instantiate(Rayo, this.transform);
    }

    //En el start recibe los componentes necesarios
    private void Start()
    {
        agentMover = GetComponent<AgentMover>();
    }

   
}
