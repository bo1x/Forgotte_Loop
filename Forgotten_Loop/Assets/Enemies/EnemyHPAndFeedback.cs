using UnityEngine;
using System.Collections;

public class EnemyHPAndFeedback : MonoBehaviour
{
    public int VidaActual = 0;
    public int VidaMax = 0;
    private int VidaAnterior;

    public Material MaterFlash;
    private Material Mater;
    private SpriteRenderer Render;
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
        if (VidaActual <= 0)
        {
            //GameObject.Find("Canvas").GetComponent<Puntos>().Almas = GameObject.Find("Canvas").GetComponent<Puntos>().Almas + 1;
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Feedback()
    {
        //Todos los efectos generales de feedback a enemigos
        
        GetComponent<AgentMover>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        Render.material = MaterFlash;
        yield return new WaitForSeconds(0.2f);
        Render.material = Mater;
        GetComponent<AgentMover>().enabled = true;
        GetComponent<EnemyAI>().enabled = true;
        
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
}
