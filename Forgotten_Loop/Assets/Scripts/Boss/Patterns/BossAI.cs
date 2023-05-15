using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //State Machine
    public enum Estado { Attack, Wait, Exposed, Death }
    public Estado Enemy = Estado.Wait;

    //Projectile Amounts
    public int amountProjectiles = 10;

    //ProjectileAngles
    [SerializeField]
    private float SpiralAngle, startAngle, endAngle, RateOfFire;

    //Animator
    private Animator myanim;

    //Bools
    public bool IsCoroutineStarted = false, HasAttacked = false, Attack = true, Exposed = false, WeakPointNotExposed = true;

    //Random Pattern Selection
    private int Pattern;

    //PatternPoint
    public Transform PatternPoint;

    private void Start()
    {
        myanim = GetComponent<Animator>();
        Pattern = Random.Range(1, 4);
        Debug.Log(Pattern);
    }

    void Update()
    {
        
        switch (Enemy)
        {
            case Estado.Attack:
                
                myanim.Play("Attack");
                switch (Pattern)
                {
                    case 1:
                        if (!IsCoroutineStarted && !HasAttacked)
                        {
                            StartCoroutine(Fire1());
                        }
                        break;

                    case 2:
                        if (!IsCoroutineStarted && !HasAttacked)
                        {
                            StartCoroutine(Fire2());
                        }
                        break;

                    case 3:
                        if (!IsCoroutineStarted && !HasAttacked)
                        {
                            StartCoroutine(Fire3());
                        }
                        break;


                    default:
                        Debug.Log("No pattern found");
                        break;
                }

                if (HasAttacked)
                {
                    Attack = true;
                    IsCoroutineStarted = false;
                    Enemy = Estado.Exposed;
                }
          
                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    StopAllCoroutines();
                    Enemy = Estado.Death;
                }
                break;

            case Estado.Wait:
                myanim.Play("Idle");
                StartCoroutine(WaitDelay());

                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    StopAllCoroutines();
                    Enemy = Estado.Death;
                }
                break;

            case Estado.Exposed:
                
                if (WeakPointNotExposed)
                {
                    myanim.Play("OpenExpose");
                }

                if (GetComponent<BossHPAndFeedback>().estoymuerto)
                {
                    StopAllCoroutines();
                    Enemy = Estado.Death;

                }
                break;

            case Estado.Death:
                Debug.Log("Dead");
                StopAllCoroutines();
                break;

            default:
                Debug.Log("MachineState NotWorking");
                break;
        }
        
    }

    public IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(2f);
        if (Attack)
        {
            HasAttacked = false;
            Attack = false;
            Enemy = Estado.Exposed;
        }
        if (Exposed)
        {
            Pattern = Random.Range(1, 4);
            Exposed = false;
            Enemy = Estado.Attack;
        }
    }

    

    private IEnumerator Fire1()
    {
        IsCoroutineStarted = true;

        startAngle = 0;
        endAngle = 720;

        float angleStep = (endAngle - startAngle) / amountProjectiles;
        float angle = startAngle;

        for (int e = 0; e < 3; e++)
        {
            for (int i = 0; i < amountProjectiles; i++)
            {
                float pDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float pDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 vectorMove = new Vector3(pDirX, pDirY, 0f);
                Vector2 pDir = (vectorMove - transform.position).normalized;

                GameObject projectile = Pooling.PoolInstantiation.InstantiateBullets();

                projectile.transform.position = PatternPoint.position;
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
                projectile.GetComponent<BossBullet>().ChangeDirection(pDir);
                projectile.GetComponent<BossBullet>().Speed = 15;

                angle += angleStep;
            }
            yield return new WaitForSeconds(1f);
        }
        
        HasAttacked = true;
    } 

   

    private IEnumerator Fire2()
    {
        IsCoroutineStarted = true;

        startAngle = 90;
        endAngle = 270;

        for (int i = 0; i < 36; i++)
        {
            float pDirX = transform.position.x + Mathf.Sin((SpiralAngle * Mathf.PI) / 180);
            float pDirY = transform.position.y + Mathf.Cos((SpiralAngle * Mathf.PI) / 180);

            Vector3 vectorMove = new Vector3(pDirX, pDirY, 0f);
            Vector2 pDir = (vectorMove - transform.position).normalized;

            GameObject projectile = Pooling.PoolInstantiation.InstantiateBullets();

            projectile.transform.position = PatternPoint.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<BossBullet>().ChangeDirection(pDir);
            projectile.GetComponent<BossBullet>().Speed = 20;

            SpiralAngle += 10;

            if (SpiralAngle >=360f)
            {
                SpiralAngle = 0f;
            }
            yield return new WaitForSeconds(0.1f);
        }
        HasAttacked = true;

    }
    private IEnumerator Fire3()
    {
        IsCoroutineStarted = true;

        startAngle = 90;
        endAngle = 270;

        for (int i = 0; i < 36; i++)
        {
            float pDirX = transform.position.x + Mathf.Sin(((SpiralAngle + 180f * i) * Mathf.PI) / 180f);
            float pDirY = transform.position.y + Mathf.Cos(((SpiralAngle + 180f * i) * Mathf.PI) / 180f);

            Vector3 vectorMove = new Vector3(pDirX, pDirY, 0f);
            Vector2 pDir = (vectorMove - transform.position).normalized;

            GameObject projectile = Pooling.PoolInstantiation.InstantiateBullets();

            projectile.transform.position = PatternPoint.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<BossBullet>().ChangeDirection(pDir);
            projectile.GetComponent<BossBullet>().Speed = 20;

            SpiralAngle += 10;

            if (SpiralAngle >= 360f)
            {
                SpiralAngle = 0f;
            }
            yield return new WaitForSeconds(0.1f);
        }
        HasAttacked = true;

    }

    public IEnumerator WindowForAttack()
    {
        yield return new WaitForSeconds(2);
        myanim.Play("CloseExpose");
        Exposed = true;
    }

    public void WaitTime()
    {
        WeakPointNotExposed = true;
        Enemy = Estado.Wait;
        
    }
    public void ExposedAnim()
    {
        myanim.Play("Exposed");
        WeakPointNotExposed = false;
        Debug.Log(1);
        StartCoroutine(WindowForAttack());
    }
}
    
    
