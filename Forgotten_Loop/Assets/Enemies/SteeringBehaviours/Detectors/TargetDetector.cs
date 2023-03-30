using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : Detector
{

    //Rango de deteccion del jugador
    [SerializeField]
    private float targetDetectionRange = 5;

    //Layers para obstaculos y jugadores
    [SerializeField]
    private LayerMask obstaclesLayerMask, playerLayerMask;

    //Gizmos
    [SerializeField]
    private bool showGizmos = false;

    //Parametros de Gizmos
    private List<Transform> colliders;

    //Sobrescribe otros metodos de mismo nombre e informacion para poder ejecutarse a la vez
    public override void Detect(AIData aiData)
    {
        //Comprueba si el jugador esta cerca con un overlap
        Collider2D playerCollider = 
            Physics2D.OverlapCircle(transform.position, targetDetectionRange, playerLayerMask);

        if (playerCollider != null)
        {
            //Comprueba si ve al jugador
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            RaycastHit2D hit = 
                Physics2D.Raycast(transform.position, direction, targetDetectionRange, obstaclesLayerMask);

            //Se asegura el collider ve esta en la Layer "Player"
            if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
            {
                //Debgug Ray para ver si funciona
                //Debug.DrawRay(transform.position, direction * targetDetectionRange, Color.magenta);
                colliders = new List<Transform>() { playerCollider.transform };
            }
            else
            {
                colliders = null;
            }
        }
        else
        {
            //Si el enemigo no ve al jugador no hay colliders
            colliders = null;
        }
        //Pasa los colliders a los objetivos de la Data
        aiData.targets = colliders;
    }

    //Gizmos
    private void OnDrawGizmosSelected()
    {
        if (showGizmos == false)
            return;

        Gizmos.DrawWireSphere(transform.position, targetDetectionRange);

        if (colliders == null)
            return;
        Gizmos.color = Color.magenta;
        foreach (var item in colliders)
        {
            Gizmos.DrawSphere(item.position, 0.3f);
        }
    }
}
