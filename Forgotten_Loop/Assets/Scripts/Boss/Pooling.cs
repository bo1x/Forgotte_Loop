using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling PoolInstantiation;

    [SerializeField]
    private GameObject PoolBullet;
    private bool NotEnoughBullets = true;

    private List<GameObject> pool;
    
    void Awake()
    {
        PoolInstantiation = this;
    }
    
    void Start()
    {
        pool = new List<GameObject>();
    }

    public GameObject InstantiateBullets()
    {
        if (pool.Count > 0)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    return pool[i];
                }
            }
        }

        if (NotEnoughBullets)
        {
            GameObject bullet = Instantiate(PoolBullet);
            bullet.SetActive(false);
            pool.Add(bullet);
            return bullet;
        }

        return null;
    }
    
    void Update()
    {
        
    }
}
