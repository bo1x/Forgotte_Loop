using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidanceBehaviour : SteeringBehaviour
{
    //Radio para evitar obstaculos y tamaño de collider del enemigo
    [SerializeField]
    private float radius = 2f, agentColliderSize = 0.6f;

    //Gizmos
    [SerializeField]
    private bool showGizmo = true;

    //Parametros Gizmos
    float[] dangersResultTemp = null;

    //Metodo anonimo para obtener los peligros e intereses y calcular el mejor camino evitando obstaculos
    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData)
    {
        foreach (Collider2D obstacleCollider in aiData.obstacles)
        {
            Vector2 directionToObstacle
                = obstacleCollider.ClosestPoint(transform.position) - (Vector2)transform.position;
            float distanceToObstacle = directionToObstacle.magnitude;

            //Calcula prioridad basada en el radio y distancia obstaculos
            float weight = distanceToObstacle <= agentColliderSize ? 1 : (radius - distanceToObstacle) / radius;

            Vector2 directionToObstacleNormalized = directionToObstacle.normalized;

            //Añade el obstaculo a los peligros del array
            for (int i = 0; i < Directions.eightDirections.Count; i++)
            {
                float result = Vector2.Dot(directionToObstacleNormalized, Directions.eightDirections[i]);

                float valueToPutIn = result * weight;

                //Sobrescribe el valor de dicha prioridad si es mayor a la actual
                if (valueToPutIn > danger[i])
                {
                    danger[i] = valueToPutIn;
                }
            }
        }
        dangersResultTemp = danger;
        return (danger, interest);
    }

    //Gizmos
    private void OnDrawGizmos()
    {
        if (showGizmo == false)
            return;

        if (Application.isPlaying && dangersResultTemp != null)
        {
            if (dangersResultTemp != null)
            {
                Gizmos.color = Color.red;
                for (int i = 0; i < dangersResultTemp.Length; i++)
                {
                    Gizmos.DrawRay(
                        transform.position,
                        Directions.eightDirections[i] * dangersResultTemp[i]*2
                        );
                }
            }
        }

    }
}

//Clase para tener las 8 direcciones principales in-game y poder usarlas para evitar obstaculos y mas
public static class Directions
{
    public static List<Vector2> eightDirections = new List<Vector2>{
            new Vector2(0,1).normalized,
            new Vector2(1,1).normalized,
            new Vector2(1,0).normalized,
            new Vector2(1,-1).normalized,
            new Vector2(0,-1).normalized,
            new Vector2(-1,-1).normalized,
            new Vector2(-1,0).normalized,
            new Vector2(-1,1).normalized
        };
}
