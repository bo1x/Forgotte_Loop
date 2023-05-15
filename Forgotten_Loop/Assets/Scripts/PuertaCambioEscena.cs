using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaCambioEscena : MonoBehaviour
{
    public int escenaCargar;


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("almas", GameObject.Find("Canvas").GetComponent<Puntos>().Almas);
            Debug.Log("Hit");
            SceneManager.LoadScene(escenaCargar);
        }
    }
}
