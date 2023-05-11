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
    public GameObject Beam;

    public Transform BeamPoint;

    public GameObject BeamParent;

    private GameObject Obj;

    private void Start()
    {
        agentMover = GetComponent<AgentMover>();
        BeamParent = this.transform.Find("BeamPoint").gameObject;
    }
    private void Update()
    {
        //El update actualiza el movimiento del enemigo
        agentMover.MovementInput = MovementInput;

        if (GetComponent<EnemyHPAndFeedback>().VidaActual <= 0)
        {
            Destroy(Obj);
            StopAllCoroutines();
        }

    }

    //Metodo de ataque
    public void attack()
    {
        //Cambiar Attack Distance en EnemyAI del enemigo para alternar la distancia a la que comienza a disparar
        //Lo mismo para el delay de ataque
       
            StartCoroutine("Cue");
        
    }

    //En el start recibe los componentes necesarios
  

    public IEnumerator Cue()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<AgentMover>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Obj = Instantiate(Beam, BeamPoint);
        Obj.GetComponent<RayBehaviour>().PuntoDisparo = BeamPoint.gameObject;


        //public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //Instantiate(Beam, BeamPoint.position, Quaternion.identity, this.gameObject.transform);
        yield return new WaitForSeconds(0.2f);
        GetComponent<EnemyAI>().enabled = true;
        GetComponent<AgentMover>().enabled = true;
    }
   
}
