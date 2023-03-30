using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generada como  Abstract para decir no puede ser un Game Object o Instancia
public abstract class SteeringBehaviour : MonoBehaviour
{
    //Metodo para almacenar los peligros e intereses en la Data
    public abstract (float[] danger, float[] interest) 
        GetSteering(float[] danger, float[] interest, AIData aiData);
}
