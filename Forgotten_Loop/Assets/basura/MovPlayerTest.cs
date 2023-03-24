using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayerTest : MonoBehaviour
{
    public float vel = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0)*vel*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0) * vel * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * vel * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * vel * Time.deltaTime;
        }

    }
}
