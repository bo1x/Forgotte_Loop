using UnityEngine;

public class VFX : MonoBehaviour
{
    public GameObject BulletEnemy;
   public void DestroyThis()
   {
       Destroy(this.gameObject);
   }

   public void Bullet()
   {
        Instantiate(BulletEnemy, transform.position, transform.rotation);
   }
}
