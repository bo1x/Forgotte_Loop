using UnityEngine;

public class EnemyHPAndFeedback : MonoBehaviour
{
    public int VidaActual = 0;
    public int VidaMax = 0;
    private int VidaAnterior;

    private void Start()
    {
        VidaActual = VidaMax;
        VidaAnterior = VidaMax;
    }
    void Update()
    {
        if (HPChecker())
        {
            Feedback();
        }
        if (VidaActual <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Feedback()
    {
        //Todos los efectos generales de feedback a enemigos
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
