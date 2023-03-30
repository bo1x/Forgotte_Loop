using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    //Detecta obstaculos, enemigos y demas y los pasa a la Data
    public abstract void Detect(AIData aiData);
}
