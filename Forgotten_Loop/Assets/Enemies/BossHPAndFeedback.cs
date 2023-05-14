using UnityEngine;
using System.Collections;

public class BossHPAndFeedback : MonoBehaviour
{
    public float VidaActual = 0;
    public float VidaMax = 0;
    private float VidaAnterior;

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

            GetComponent<Animator>().Play("Death");
            Destroy(this.gameObject, 1f);
        }
    }

    public IEnumerator Feedback()
    {
        //Todos los efectos generales de feedback a enemigos

        Render.material = MaterFlash;
        yield return new WaitForSeconds(0.2f);
        Render.material = Mater;
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
