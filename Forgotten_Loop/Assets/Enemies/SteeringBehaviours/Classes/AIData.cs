using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIData : MonoBehaviour
{
    //Collecion de obstaculos y objetivos (jugador)
    public List<Transform> targets = null;
    public Collider2D[] obstacles = null;

    //Objetivo actual
    public Transform currentTarget;

    private void Update()
    {
        if (currentTarget != null)
        {
            if (currentTarget.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    //Cuenta los objetivos actuales, dando la posibilidad de que haya
    public int GetTargetsCount()
    {
        if (targets == null)
        {
            return 0;
        }
        else
        {
            return targets.Count;
        }
    }
}
