using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMover : MonoBehaviour
{
    //Rigibody del enemigo
    private Rigidbody2D rb2d;

    //Variables para velocidad en general
    [SerializeField]
    private float maxSpeed = 2, acceleration = 50, deacceleration = 100;
    [SerializeField]
    private float currentSpeed = 0;

    //Movement Inputs en Vectores que usan ademas properties
    private Vector2 oldMovementInput;
    public Vector2 MovementInput { get; set; }

    //Adquiere el rb por Start
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //En el Update en vase a la velocidad y los datos dados calcula la velocidad, aceleracion y decerelacion correspondiente
    private void FixedUpdate()
    {
        if (MovementInput.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = MovementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb2d.velocity = oldMovementInput * currentSpeed;

    }


}
