using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Control : MonoBehaviour
{
    //Variables para movimiento de jugador y raton
    private float InputX, InputY;
    
    private float PointX, PointY;
    
    //Variables para cambiar el timing del dash
    [SerializeField]
    public float DashCooldown, DashTime;
   
    //Variables para permitir Dash o no
    private bool IsDashing = false, CanDash = true;

    //Variables para alternar velocidad de movimiento y dash
    public float movespeed, dashspeed;

    //Variables de GameObjects y Componentes necesarios para el PlayerController
    private Rigidbody2D myrigi;

    private GameObject mirilla;

    private WeaponParent weaponParent;

    //El start añade a las variables previamente mencionadas lo que necesita
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
        mirilla = GameObject.Find("Pointer");
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void Update()
    {
        //Comprueba si esta o no en dash, sino lo esta es movimiento normal
        if (!IsDashing)
        {
            myrigi.velocity = new Vector2(InputX * movespeed, InputY * movespeed);
        }

        //Usa un metodo para mover la mirilla en tiempo real  dandole la posicion
        mirilla.transform.position = PositionMouse();

        //El arma apunta tambien a la mirlilla, mediante este codigo se le pasa al script del arma la susodicha posicion
        weaponParent.PointerPosition = mirilla.transform.position;

        //Este metodo cambia la posicion en la que mira jugador de acuerdo a donde esta el raton
        RotateViewOnMouse();
        
    }

    //Recibe por Inputs el movimiento del jugador en X y Y
    public void OnMoveX(InputAction.CallbackContext context)
    {
        InputX = context.ReadValue<Vector2>().x;
        InputY = context.ReadValue<Vector2>().y;
    }

    //Rota al jugador dependiendo de la direccion del raton, simplemente cambiando la rotacion en Y
    public void RotateViewOnMouse()
    {
        if (weaponParent.direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (weaponParent.direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    //Recibe por Inputs el movimiento del raton en X y Y
    public void Point(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != Vector2.zero)
        {
            PointX = context.ReadValue<Vector2>().x;
            PointY = context.ReadValue<Vector2>().y;
        }
            
    }

    //Detecta la posicion del raton en pantalla y lo guarda en un vector3
    private Vector3 PositionMouse()
    {
       Vector3 MouseP = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(PointX, PointY)).x, Camera.main.ScreenToWorldPoint(new Vector3(PointX, PointY)).y, 0);
       return MouseP;
    }

    //Inicia la corrutina de dash si puede realizarlos
    public void Dodge(InputAction.CallbackContext context)
    {
        if (context.performed && CanDash)
        {
            StartCoroutine("Dash");
        }

    }

    //Aumenta la velocidad instantaneamente cambiando los bools correspondientes y llama a la corrutina Delay
    public IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        myrigi.velocity = new Vector2(myrigi.velocity.x * dashspeed, myrigi.velocity.y * dashspeed);
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
        StartCoroutine(("Delay"));
    }

    //Pone un Delay/Cooldown entre dashes para que no se spameen
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;
    }

    //Metodos para mecanicas varias por InputActions
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("GetInteractedFool");
        }
    }

    public void ItemUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("ItemHasDied");
        }
    }

    public void PauseMenu(InputAction.CallbackContext context)
    {   
            if(context.performed)
            {
              print("PauseMenu");
            }
    }

    public void Map(InputAction.CallbackContext context)
    {
        
        if(context.performed)
        {
            
            print("Mapa Appear");
            
        }

        if(context.canceled)
        {
            print("Mapa Disappear");
        }
    }

    public void RangeAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Piu Piu");
        }
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("HYAAAAAAA");
        }
    }


}
