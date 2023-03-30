using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextSolver : MonoBehaviour
{
    //Bool Gizmos
    [SerializeField]
    private bool showGizmos = true;

    //Parametros Gizmo
    float[] interestGizmo = new float[0];
    Vector2 resultDirection = Vector2.zero;
    private float rayLength = 2;

    //Gizmos en el start
    private void Start()
    {
        interestGizmo = new float[8];
    }

    //Metodo para obtener la direccion en la que moverse en base a la data
    public Vector2 GetDirectionToMove(List<SteeringBehaviour> behaviours, AIData aiData)
    {
        float[] danger = new float[8];
        float[] interest = new float[8];

        //Loop para cada comportamiento teniendo en cuenta los peligros (Obstaculos) y intereses (El jugador)
        foreach (SteeringBehaviour behaviour in behaviours)
        {
            (danger, interest) = behaviour.GetSteering(danger, interest, aiData);
        }

        //Resta los peligros del array de intereses
        for (int i = 0; i < 8; i++)
        {
            interest[i] = Mathf.Clamp01(interest[i] - danger[i]);
        }

        interestGizmo = interest;

        //Saca la direccion general
        Vector2 outputDirection = Vector2.zero;
        for (int i = 0; i < 8; i++)
        {
            outputDirection += Directions.eightDirections[i] * interest[i];
        }

        outputDirection.Normalize();

        resultDirection = outputDirection;

        //Devuelve la direccion seleccionada en el metodo
        return resultDirection;
    }

    //Gizmos
    private void OnDrawGizmos()
    {
        if (Application.isPlaying && showGizmos)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, resultDirection * rayLength);
        }
    }
}
