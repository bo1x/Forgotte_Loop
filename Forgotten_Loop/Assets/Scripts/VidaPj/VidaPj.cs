using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPj : MonoBehaviour
{

    public int VidaActual;
    public int VidaMaxima;
    public int VidaAnterior;

    public float tiempoImnunidad;
    private float tiempoPasado;
    
    private GameObject canvasitofachero;

    public Material MaterFlash;
    public Material Mater;
    private SpriteRenderer Render;

    public AudioSource source;
    public AudioClip audiomenosvida;

    // Start is called before the first frame update
    void Start()
    {
        VidaMaxima = VidaMaxima * (int)PlayerPrefs.GetFloat("vidaMax");
        VidaActual = VidaMaxima;
        VidaAnterior = VidaMaxima;
        canvasitofachero = GameObject.Find("Canvas");

        Render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // check para saber si el sistema de vidas funsiona jeje Debug.Log("Vida" + VidaMaxima);
        tiempoPasado = tiempoPasado + Time.deltaTime;

        //canvasitofachero.GetComponent<Vida>().vida = VidaActual;
        if (HPChecker())
        {
            StartCoroutine("Feedback");
        }

        if (VidaActual <= 0)
        {
            PlayerPrefs.SetFloat("almas", canvasitofachero.GetComponent<Puntos>().Almas);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (tiempoPasado>tiempoImnunidad)
            {
                VidaActual = VidaActual - 1;
                tiempoPasado = 0;
                //Vcam = GameObject.Find("CM vcam1");
                //Vcam.GetComponent<cameraShake>().Shake(0.3f, 0.5f, 0.3f);                      
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAttack")
        {
            if (tiempoPasado > tiempoImnunidad)
            {
                VidaActual = VidaActual - 1;
                tiempoPasado = 0;                     
            }
        }
    }

    public bool HPChecker()
    {
        if (VidaActual < VidaAnterior)
        {
            VidaAnterior = VidaActual;
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator Feedback()
    {
        //Todos los efectos generales de feedback a jugador
        Render.material = MaterFlash;
        sonidodanio();
        GameObject.Find("Weapon").GetComponent<SpriteRenderer>().material = MaterFlash;
        yield return new WaitForSeconds(0.2f);
        Render.material = Mater;
        GameObject.Find("Weapon").GetComponent<SpriteRenderer>().material = Mater;
        StartCoroutine(Parpadeo());
    }

    public IEnumerator Parpadeo()
    {
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, 0);
        yield return new WaitForSeconds(tiempoImnunidad / 5);
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, 1);
        yield return new WaitForSeconds(tiempoImnunidad / 5);
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, 0);
        yield return new WaitForSeconds(tiempoImnunidad / 5);
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, 1);
        yield return new WaitForSeconds(tiempoImnunidad / 5);
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, 0);
        yield return new WaitForSeconds(tiempoImnunidad / 5);
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, 1);
        
    }

    public void sonidodanio()
    {
        source.clip = audiomenosvida;
        source.Play();
        
    }
   
}

