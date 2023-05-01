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

    private Animator myanim;

    //Cambia entre armas
    public bool ModoDisparo = false;

    //Variables de Arma
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float nextShoot;
    public float fireRate = 0.5f;

    //Variables Arma Anim
    public int Armas;

    public GameObject Renderer;

    public Sprite Arma1;
    public Sprite Arma2;
    public Sprite Arma3;

    //El start añade a las variables previamente mencionadas lo que necesita
    void Start()
    {
        myanim = GetComponent<Animator>();
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

        if (myrigi.velocity == Vector2.zero)
        {
            myanim.Play("Idle");
        }
        if (myrigi.velocity != Vector2.zero)
        {
            switch (Armas)
            {
                default:
                    Debug.Log("No Anim");
                    break;
                case 0:
                    myanim.Play("RunSideToSide");
                    break;
                case 1:
                    myanim.Play("RunSideToSide2");
                    break;
                case 2:
                    myanim.Play("RunSideToSide2");
                    break;
                case 3:
                    myanim.Play("RunSideToSide1");
                    break;
            }
        }
        switch (Armas)
        {
            default:
                Debug.Log("No Weapon");
                break;
            case 0:
                Renderer.GetComponent<SpriteRenderer>().sprite = null;               
                break;
            case 1:
                Renderer.GetComponent<SpriteRenderer>().sprite = Arma1;
                break;
            case 2:
                Renderer.GetComponent<SpriteRenderer>().sprite = Arma2;
                break;
            case 3:
                Renderer.GetComponent<SpriteRenderer>().sprite = Arma3;
                break;
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
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (weaponParent.direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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
    public Vector3 PositionMouse()
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
        myrigi.AddForce(new Vector2 (myrigi.velocity.x * dashspeed, myrigi.velocity.y * dashspeed));
        GetComponentInChildren<Collider>().enabled = false;
        yield return new WaitForSeconds(DashTime);
        GetComponentInChildren<Collider>().enabled = true;
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
            switch (Armas)
            {
                default:
                    print("No Weapon");
                    break;
                case 1:
                    break;
                case 1:
                    break;
                case 1:
                    break;

            }
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + fireRate;
                Instantiate(bulletPrefab, shootingPoint.transform);
            }
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
