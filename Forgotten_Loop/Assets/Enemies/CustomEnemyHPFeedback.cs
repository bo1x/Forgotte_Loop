using UnityEngine;
using System.Collections;

public class CustomEnemyHPFeedback : MonoBehaviour
{
    public int VidaActual = 0;
    public int VidaMax = 0;
    private int VidaAnterior;

    public int NumeroMinimoAlmas = 0;
    public int NumeroMaximoAlmas = 10;
    private int numeroAleatorio;
    public GameObject alma;

    public Material MaterFlash;
    private Material Mater;
    private SpriteRenderer Render;
    public bool estoymuerto = false;


    private void Start()
    {
        VidaActual = VidaMax;
        VidaAnterior = VidaMax;
        Render = GetComponent<SpriteRenderer>();
        Mater = Render.material;
    }
    void Update()
    {
        if (HPChecker())
        {
            StartCoroutine("Feedback");
        }
        if (VidaActual <= 0 && estoymuerto == false)
        {

            estoymuerto = true;


            numeroAleatorio = Random.Range(NumeroMinimoAlmas, NumeroMaximoAlmas + 1);

            for (int i = 0; i < numeroAleatorio; i++)
            {
                Instantiate(alma, new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0), transform.rotation);
            }

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<AgentMover>().enabled = false;
            GetComponent<EnemyAI>().enabled = false;

            GetComponent<Animator>().Play("Death");
        }
    }

    public IEnumerator Feedback()
    {
        //Todos los efectos generales de feedback a enemigos

        GetComponent<EnemyAI>().enabled = false;
        Render.material = MaterFlash;
        yield return new WaitForSeconds(0.2f);
        Render.material = Mater;
        if (VidaActual > 0)
        { 
            GetComponent<EnemyAI>().enabled = true;
        }


    }

    public bool HPChecker()
    {
        if (VidaActual != VidaAnterior)
        {
            VidaAnterior = VidaActual;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
