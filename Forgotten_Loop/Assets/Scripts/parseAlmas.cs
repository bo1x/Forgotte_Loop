using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parseAlmas : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject canvas;
    public int almas;
    public int restaAlmas = 0;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        almas = canvas.GetComponent<Puntos>().Almas;
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.activeSelf)
        {
            almas = canvas.GetComponent<Puntos>().Almas;

            if (restaAlmas > 0)
            {
                canvas.GetComponent<Puntos>().Almas = canvas.GetComponent<Puntos>().Almas - restaAlmas;
                PlayerPrefs.SetFloat("almas", almas = canvas.GetComponent<Puntos>().Almas);
                restaAlmas = 0;
            }
        }

      
    }
}
