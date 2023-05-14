
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentMeleeEye : MonoBehaviour
{ 
    //El script que mueve al personaje
    private AgentMover agentMover;

    //El animator
    public Animator myanim;

    public Vector2 dir;

    public bool HasAttackFinished = true;

    

    //Inputs para movimiento y raton
    private Vector2 pointerInput, movementInput;

    //Propiedades que reciben el input del enemigo y el puntero para saber la posicion del player y poder apuntar
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Update()
    {
        //El update actualiza el movimiento del enemigo
        agentMover.MovementInput = MovementInput;
        dir = (GameObject.Find("Player").transform.position - this.transform.position).normalized;

        if (GetComponent<EnemyHPAndFeedback>().VidaActual <= 0)
        {
            GetComponent<EnemyHPAndFeedback>().enabled = true;
            StopAllCoroutines();
        }
    }

    //Metodo de ataque
    public void attack()
    {
        if (HasAttackFinished && GetComponent<EnemyHPAndFeedback>().VidaActual > 0)
        {
            myanim.Play("AttackStart");
        }
    }

    //En el start recibe los componentes necesarios
    private void Start()
    {
        agentMover = GetComponent<AgentMover>();
        myanim = GetComponent<Animator>();
    }

    

    public IEnumerator Throw()
    {
        HasAttackFinished = false;
        GetComponent<AgentMover>().enabled = false;
        GetComponent<AIData>().enabled = false;
        transform.up = -dir;
        GetComponent<Rigidbody2D>().AddForce(dir * 1000);
        GetComponent<EnemyHPAndFeedback>().enabled = false;
        yield return new WaitForSeconds(2f);
        GetComponent<EnemyHPAndFeedback>().enabled = true;
        GetComponent<AgentMover>().enabled = true;
        GetComponent<AIData>().enabled = true;
        myanim.Play("AttackFinish");
        HasAttackFinished = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HasAttackFinished)
        {
            if (collision.gameObject.name == "Walls")
            {
                StopAllCoroutines();
                GetComponent<EnemyHPAndFeedback>().enabled = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x * -1, dir.y * -1) * 1000);
                GetComponent<AgentMover>().enabled = true;
                GetComponent<AIData>().enabled = true;
                HasAttackFinished = true;
                GetComponent<EnemyHPAndFeedback>().StartCoroutine("Feedback");
                myanim.Play("AttackFinish");
            }


            if (collision.gameObject.name == "Collideable")
            {
                StopAllCoroutines();
                GetComponent<EnemyHPAndFeedback>().enabled = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x * -1, dir.y * -1) * 1000);
                GetComponent<AgentMover>().enabled = true;
                GetComponent<AIData>().enabled = true;
                HasAttackFinished = true;
                GetComponent<EnemyHPAndFeedback>().StartCoroutine("Feedback");
                myanim.Play("AttackFinish");
            }

            if (collision.gameObject.tag == "Player")
            {
                StopAllCoroutines();
                GetComponent<EnemyHPAndFeedback>().enabled = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x * -1, dir.y * -1) * 1000);
                GetComponent<AgentMover>().enabled = true;
                GetComponent<AIData>().enabled = true;
                HasAttackFinished = true;
                GetComponent<EnemyHPAndFeedback>().StartCoroutine("Feedback");
                Impacto(collision);
                myanim.Play("AttackFinish");
            }
        }
    }

    public void Impacto(Collision2D collision)
    {
        Vector2 Knockdir = (transform.position - GameObject.Find("Player").transform.position).normalized;
        collision.gameObject.GetComponent<Control>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-Knockdir * 5, ForceMode2D.Impulse);

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
