using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    //Lista para los comportamientos de direccion
    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    //Lista de Detectores
    [SerializeField]
    private List<Detector> detectors;

    //Datos acumulados de la IA
    [SerializeField]
    private AIData aiData;

    //Variables para delays y distancia para ataque
    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 0.5f;

    //Inputs de la IA Enemiga a su propio controller
    public UnityEvent OnAttackPressed;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;

    [SerializeField]
    private Vector2 movementInput;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    bool following = false;

    private void Start()
    {
        //Deteccion cada x tiempo del personaje y los obstaculos
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }
    
    //Metodo para ejecutar la deteccion en base al script Detector
    private void PerformDetection()
    {
        foreach (Detector detector in detectors)
        {
            detector.Detect(aiData);
        }
    }

    private void Update()
    {
        //Mueve a la IA enemiga en base a la posicion de sus objetivo/s (El player basicamente)
        if (aiData.currentTarget != null)
        {
            //Logica para mirar al personaje (Un poco inutil graficamente de momento pero servira a futuro)
            OnPointerInput?.Invoke(aiData.currentTarget.position);
            if (following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            //Logica de adquisicion de objetivos (El player basicamente)
            aiData.currentTarget = aiData.targets[0];
        }
        //Movimiento del agente en base a Unity Eventes
        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            //Logica para Idle
            Debug.Log("Stopping");
            movementInput = Vector2.zero;
            following = false;
            yield break;
        }
        else
        {
            float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if (distance < attackDistance)
            {
                //Logica de ataque
                movementInput = Vector2.zero;
                OnAttackPressed?.Invoke();
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                //Logica de perescucion
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }

        }

    }
}
