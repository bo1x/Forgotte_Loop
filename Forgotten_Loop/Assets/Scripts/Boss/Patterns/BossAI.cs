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

    public WaitForSeconds DelayWait = new WaitForSeconds(0f);

    public bool IsCoroutineStarted = false, HasAttacked = false;

    public int Pattern = 1;
    private void Start()
    {
        myanim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (Enemy)
        {
            case Estado.Attack:

                switch (Pattern)
                {
                    case 1:
                        Fire1();
                        break;

                    case 2:
                        if (!IsCoroutineStarted)
                        {
                            StartCoroutine(Fire2());
                        }
                        break;

                    case 3:
                        break;


                    default:
                        Debug.Log("No pattern found");
                        break;
                }

                if (HasAttacked)
                {
                    Enemy = Estado.Exposed;
                }
          
                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    Enemy = Estado.Death;
                }
                break;

            case Estado.Wait:
                myanim.Play("Idle");
                StartCoroutine(WaitDelay());

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
                Debug.Log("Dead");
                break;

            default:
                Debug.Log("MachineState NotWorking");
                break;
        }
    }

    public IEnumerator WaitDelay()
    {
        yield return DelayWait;
    }

    private void Fire1()
    {
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
        HasAttacked = true;
    } 

    private IEnumerator Fire2()
    {
        IsCoroutineStarted = true;
        for (int i = 0; i < 36; i++)
        {
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
            yield return new WaitForSeconds(0.1f);
        }
        StopCoroutine(Fire2());   
            
    }

    public void Exposed()
    {
        myanim.Play("Exposed");
    }

    public void FinishWeakPoint()
    {

    }
}
    
    
