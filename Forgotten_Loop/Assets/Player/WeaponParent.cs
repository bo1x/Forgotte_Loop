using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    //Una property que toma y usa la posicion del raton segun las necesita
    public Vector2 PointerPosition { get; set; }

    //Vector2 para saber la direccion del raton en base a su posicion
    public Vector2 direction;

    private void Update()
    {
        //Calcula la direcion en base a la posicion del raton y su propia (pasada a un vector2), lo normaliza y 0 son 180 grados y 1 son otros 180
        direction = (PointerPosition - (Vector2)transform.position).normalized;

        //Establece su posicion derecha como la direccion, es decir la posicion del raton
        transform.right = direction;

        //Guarda su escala para despues
        Vector2 scale = transform.localScale;

        //Cambia la escala y por tanto la orientacion dependiendo de la direccion
        if (direction.x < 0)
        {
            scale.y = -1;
            
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }

        //Settea la escala una vez ha realizado los cambios correspondientes
        transform.localScale = scale;
    }

   
}
