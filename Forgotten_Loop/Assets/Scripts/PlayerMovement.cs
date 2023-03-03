using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {//Character movement

        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(0, 5.0f * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(0, -5.0f * Time.deltaTime, 0);
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(-5.0f * Time.deltaTime, 0, 0);
        }
            
        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(5.0f * Time.deltaTime, 0, 0);
        }
          
    }
}