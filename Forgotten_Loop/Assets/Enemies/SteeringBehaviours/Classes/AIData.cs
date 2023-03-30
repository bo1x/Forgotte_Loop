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
