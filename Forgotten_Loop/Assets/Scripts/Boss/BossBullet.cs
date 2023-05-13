using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector2 Direction;

    
    public float Speed;

    private Rigidbody2D myrigi;

    public void OnEnable()
    {
        Invoke("SetOff", 3f);
    }

    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        myrigi.velocity = Direction * Speed;
    }

    public void ChangeDirection(Vector2 dir)
    {
        Direction = dir;
    }

    private void SetOff()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        CancelInvoke();
    }
}
