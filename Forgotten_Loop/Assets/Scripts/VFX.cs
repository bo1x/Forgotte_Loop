using UnityEngine;

public class VFX : MonoBehaviour
{
    public GameObject Beams;
   public void DestroyThis()
   {
       Destroy(this.gameObject);
   }

   public void Beam()
   {
        Instantiate(Beams, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
   }
}
