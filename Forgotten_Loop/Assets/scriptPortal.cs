using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPortal : MonoBehaviour
{

    public int escenaCargar;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.Play("abrir");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void reproducirIDLE()
    {
        anim.Play("idle");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("almas", GameObject.Find("Canvas").GetComponent<Puntos>().Almas);
            Debug.Log("Hit");
            SceneManager.LoadScene(escenaCargar);
        }
    }
}
