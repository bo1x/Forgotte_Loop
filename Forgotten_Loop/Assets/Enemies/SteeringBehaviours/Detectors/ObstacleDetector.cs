using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : Detector
{
    //Radio de deteccion
    [SerializeField]
    private float detectionRadius = 2;

    //Layer de los obstaculos
    [SerializeField]
    private LayerMask layerMask;

    //Gizmos
    [SerializeField]
    private bool showGizmos = true;

    //Array de colliders
    Collider2D[] colliders;

    //Detecta los colliders con un Overlap y los añade al script de Data, usa override para sobrescribir el metodo del detector
    public override void Detect(AIData aiData)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);
        aiData.obstacles = colliders;
    }

    //Gizmos
    private void OnDrawGizmos()
    {
        if (showGizmos == false)
            return;
        if (Application.isPlaying && colliders != null)
        {
            Gizmos.color = Color.red;
            foreach (Collider2D obstacleCollider in colliders)
            {
                Gizmos.DrawSphere(obstacleCollider.transform.position, 0.2f);
            }
        }
    }
}
