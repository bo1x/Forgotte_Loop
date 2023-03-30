using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParentMelee : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public Vector2 direction;

    private bool AttackBlocked = false;

    private void Update()
    {
        direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
            
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }

    public void Attack()
    {
        if (AttackBlocked)
            return;
        AttackBlocked = true;
        StartCoroutine(("Delay"));
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(3f);
        AttackBlocked = false;
    }

   
}
