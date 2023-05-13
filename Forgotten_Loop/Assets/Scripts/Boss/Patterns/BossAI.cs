using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //State Machine
    public enum Estado { Attack, Wait, Exposed, Death }
    public Estado Enemy = Estado.Attack;

    //Projectile Amounts
    public int amountProjectiles = 10;

    //ProjectileAngles
    [SerializeField]
    private float SpiralAngle, startAngle, endAngle, RateOfFire;

    private Vector2 projectilesDirection;

    private bool IsRoFSet = false;

    //Animator

    private Animator myanim;

    private void Start()
    {
        myanim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (Enemy)
        {
            case Estado.Attack:
                Fire1();
                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    Enemy = Estado.Death;
                }
                break;
            case Estado.Wait:

                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    Enemy = Estado.Death;
                }
                break;
            case Estado.Exposed:

                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    Enemy = Estado.Death;
                }
                break;
            case Estado.Death:
                Debug.Log("MachineState NotWorking");
                break;
            default:
                Debug.Log("MachineState NotWorking");
                break;
        }
    }



    private void Fire1()
    {
        if (!IsRoFSet)
        {
            RateOfFire = 1f;
            IsRoFSet = true;
        }
        float angleStep = (endAngle - startAngle) / amountProjectiles;
        float angle = startAngle;

        for (int i = 0; i < amountProjectiles; i++)
        {
            float pDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI)/180);
            float pDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI)/180);

            Vector3 vectorMove = new Vector3(pDirX, pDirY, 0f);
            Vector2 pDir = (vectorMove - transform.position).normalized;

            GameObject projectile = Pooling.PoolInstantiation.InstantiateBullets();

            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<BossBullet>().ChangeDirection(pDir);
            projectile.GetComponent<BossBullet>().Speed = 15;

            angle += angleStep;
        }
        Enemy = Estado.Death;
    } 

    private void Fire2()
    {
        if (!IsRoFSet)
        {
            RateOfFire = 0.1f;
            IsRoFSet = true;
        }
        float pDirX = transform.position.x + Mathf.Sin((SpiralAngle * Mathf.PI) / 180);
            float pDirY = transform.position.y + Mathf.Cos((SpiralAngle * Mathf.PI) / 180);

            Vector3 vectorMove = new Vector3(pDirX, pDirY, 0f);
            Vector2 pDir = (vectorMove - transform.position).normalized;

            GameObject projectile = Pooling.PoolInstantiation.InstantiateBullets();

            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<BossBullet>().ChangeDirection(pDir);
            projectile.GetComponent<BossBullet>().Speed = 15;

            SpiralAngle += 10;
    }
}
    
    
