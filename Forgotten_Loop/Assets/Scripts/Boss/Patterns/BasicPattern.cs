using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPattern : MonoBehaviour
{
    [SerializeField]
    private int amountProjectiles = 10;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;

    private Vector2 projectilesDirection;

    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / amountProjectiles;
        float angle = startAngle;

        for (int i = 0; i < amountProjectiles; i++)
        {
            float pDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI)/360);
            float pDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI)/360);

            Vector3 vectorMove = new Vector3(pDirX, pDirY, 0f);
            Vector2 pDir = (vectorMove - transform.position);

            GameObject projectile = Pooling.PoolInstantiation.InstantiateBullets();

            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<BossBullet>().ChangeDirection(pDir);
            projectile.GetComponent<BossBullet>().Speed = 15;

            angle += angleStep;
        }
    } 
}
    
    
