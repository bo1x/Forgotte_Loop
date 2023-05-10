using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmasDrops : MonoBehaviour
{
    private GameObject player;
    public float Acercar = 5f;
    public float VelocidadAlma = 5f;
    public float Coger = 2f;

    private float contadorHastaAcercamiento = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        contadorHastaAcercamiento = contadorHastaAcercamiento + Time.deltaTime;
        if (Vector2.Distance(transform.position, player.transform.position) < Acercar && contadorHastaAcercamiento>2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, VelocidadAlma * Time.deltaTime);

            if (Vector2.Distance(transform.position,player.transform.position) < Coger)
            {
                GameObject.Find("Canvas").GetComponent<Puntos>().Almas++;
                Destroy(this.gameObject);
            }
        }
    }
}



