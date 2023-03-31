using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject player;
    private bool playerDentroSala = false;
    private bool salaActivada = false;
    public Transform[] pos;
    public GameObject prefabEnemigo;
    public bool enemigosVivos = true;
    public GameObject collidersLevel;
    private int numeroenemigosVivos;
    

    List<GameObject> listaEnemigos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Respawn");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerDentroSala)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                Instantiate(prefabEnemigo, pos[i]);
                numeroenemigosVivos = numeroenemigosVivos + 1;
            }
            listaEnemigos.AddRange(GameObject.FindGameObjectsWithTag("Enemigos"));
            print(listaEnemigos.Count);
        }
     
       
        if (!enemigosVivos)
        {
            collidersLevel.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerDentroSala = true;
        }
    }

}
