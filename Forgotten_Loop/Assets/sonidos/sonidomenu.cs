using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidomenu : MonoBehaviour
{
    public AudioSource source;
    public AudioClip audio1;

    private void Start()
    {
        Cursor.visible = true;
    }
    public void button1()
    {
        source.clip = audio1;
        source.Play();
        Debug.Log("sonido ON");
    }
   
  
}
