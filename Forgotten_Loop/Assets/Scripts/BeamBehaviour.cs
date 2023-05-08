using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    public GameObject VFX;
    public int daño = 1;

    public float tiempoImnunidad = 0.5f;
    private float tiempoPasado;
    private bool DamageTime = true;

    void Start()
    {
        daño = daño * (int)PlayerPrefs.GetFloat("daño");

    }

    private void Update()
    {
        
        tiempoPasado = tiempoPasado + Time.deltaTime;
        if (tiempoPasado > tiempoImnunidad)
        {
            DamageTime = true;
            tiempoPasado = 0;

        }
        Collider2D beam = Physics2D.OverlapBox(transform.position, new Vector2(6.099516f, 0.3582758f), transform.rotation.z);
            if (beam.gameObject.tag == "Enemy")
            {
                if (DamageTime)
                {
                    DamageTime = false;
                    ImpactoBala(beam);   
                }
            }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(6.099516f, 0.3582758f));
    }

    

    void ImpactoBala(Collider2D collider)
    {
        collider.gameObject.GetComponent<EnemyHPAndFeedback>().VidaActual -= daño;
        Vector2 dir = (transform.position - collider.transform.position).normalized;
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 10, ForceMode2D.Impulse);
        Instantiate(VFX, transform.position, transform.rotation);
        
    }

    
}
