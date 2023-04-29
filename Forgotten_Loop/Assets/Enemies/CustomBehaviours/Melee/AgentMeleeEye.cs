using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentMeleeEye : MonoBehaviour
{

    public bool a = false;

    //El script que mueve al personaje
    private AgentMover agentMover;

    //Inputs para movimiento y raton
    private Vector2 pointerInput, movementInput;

    //Propiedades que reciben el input del enemigo y el puntero para saber la posicion del player y poder apuntar
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Update()
    {
        //El update actualiza el movimiento del enemigo
        agentMover.MovementInput = MovementInput;

    }

    //Metodo de ataque
    public void attack()
    {
        GetComponent<EnemyAIThrow>().movementInput = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine("Delay");
        if (a)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right;
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            StartCoroutine("Delay2");
        }

    }

    //En el start recibe los componentes necesarios
    private void Start()
    {
        agentMover = GetComponent<AgentMover>();
    }


    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        a = true;
    }

    public IEnumerator Delay2()
    {
        yield return new WaitForSeconds(1f);
        a = false;
    }

}
