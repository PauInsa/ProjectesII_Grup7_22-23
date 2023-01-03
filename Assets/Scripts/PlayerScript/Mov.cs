using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    [Header ("Particles")]
    public ParticleSystem runDust;
    

    [Header("Video")]
    public float MoveSpeed;
    public float acceleration;
    public float decceleration;
    public float velPower;
    public float FrictionAmount;
    private bool isJumping = false;
    public float RecoilForce;

    [Header("Animator")]
    public Animator animator;

    [Header("Movimiento")]
    private float horizontal;
    private float vertical;
    public float maxSpeedX;
    public float maxSpeedY;
    private bool grounded;
    public float movementMagnitude;

    [Header("Salto")]
    public float jumpMagnitude;
    bool isFacingRight = true;

    [Header ("Drag")]
    public float inicialDrag;
    public float multiplicadorCancelarSalto;
    public float multiplicadorGravedad;
    private float escalarGravedad;
    private bool botonSaltoArriba = true;
    private bool saltar;

    private bool A_Up;
    private bool D_Up;

    private float tiempoA_UP = 0.2f;
    private float tiempoD_UP = 0.2f;

    [Header ("CoyoteTime")]
    public float coyoteTime;
    private float coyoteTimeCounter;


    public Pistola pistolaScript;

    [Header ("Audio")]
    public AudioSource fireSound;

    [Header ("Asociaciones")]
    public Transform personaje;

    public Transform rayOriginTransform;

    public Rigidbody2D rb;

    public bool together = false;

    //[Header ("Salto en  la pared")]
    //public Transform controladorPared;
    //public Vector3 BoxSize;
    //private bool wall;
    //private bool deslizando;
    //public float deslizVelocity;
    //private LayerMask pared;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        horizontal = Input.GetAxisRaw("Horizontal");
        escalarGravedad = rb.gravityScale;
    } 

    // Update is called once per frame
    void Update()
    {
        //Comprobar si estan unidos
        together = pistolaScript.isWithPlayer;

        //animacion
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (together == true)
        {
            animator.SetBool("WithWeapon", true);
        }
        else
            animator.SetBool("WithWeapon", false);

        //Mov
        //if (!together)
        //{
        //    maxSpeedX = 4.0f;
        //    maxSpeedY = 31.5f;
        //    movementMagnitude = 24.0f;
        //    jumpMagnitude = 54.1f;
        //}
        //else
        //{
        //    maxSpeedX = 3.0f;
        //    maxSpeedY = 31.5f;
        //    movementMagnitude = 16.0f;
        //    jumpMagnitude = 0.0f;
        //}

        //Movimiento
        grounded = Physics2D.Raycast(rayOriginTransform.position, Vector2.down, 0.2f);

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            A_Up = false;
            D_Up = false;
            horizontal = 0.0f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            
        }
        else if (Input.GetKey(KeyCode.S))
        {

        }
        else if (Input.GetKey(KeyCode.A))
        {
            A_Up = false;
            horizontal = -1.0f;
            //Run();
            Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            D_Up = false;
            horizontal = 1.0f;
            //Run();
            Flip();
        }
        else
        {
            horizontal = 0.0f;
        }

        //Friccion
        if (Input.GetKeyUp(KeyCode.A))
        {
            A_Up = true;
            tiempoA_UP = 0.2f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            D_Up = true;
            tiempoD_UP = 0.2f;
        }


        //------------------Rozamiento
        if(tiempoA_UP >= 0)
        {
            tiempoA_UP -= Time.deltaTime;
        }

        if (tiempoD_UP >= 0)
        {
            tiempoD_UP -= Time.deltaTime;
        }


        if (D_Up && A_Up)
        {
            if (rb.drag < 8)
                rb.drag += 1f;
        }
        else if (!D_Up && tiempoA_UP > 0 && grounded) //Estabas yendo hacia la izquierda y justo has cambiado de direccion
        {
            if (rb.drag < 8)
                rb.drag += 1.8f;
        }
        else if (!A_Up && tiempoD_UP > 0 && grounded) //Estabas yendo hacia la derecha y justo has cambiado de direccion
        {
            if (rb.drag < 8)
                rb.drag += 1.8f;
        }
        else
        {
            rb.drag = inicialDrag;
        }




        //------------------Coyotetime
        if(grounded)
        {
            coyoteTimeCounter = coyoteTime;
            animator.SetBool("isJumping", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            animator.SetBool("isJumping", true);
        }



        //-----------------------Salto
        if (Input.GetKey(KeyCode.Space))
        {
            A_Up = false;
            D_Up = false;
            saltar = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //ButtonJump();
            A_Up = true;
            D_Up = true;
        }


        //rb.AddForce(new Vector2(horizontal * movementMagnitude, 0));

        //if (Mathf.Abs(rb.velocity.y) > maxSpeedY)
        //    rb.velocity = new Vector2(rb.velocity.x, maxSpeedY * Mathf.Sign(rb.velocity.y));
        //else if (Mathf.Abs(rb.velocity.x) > maxSpeedX)
        //    rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        //else if(Mathf.Abs(rb.velocity.y) > maxSpeedY && Mathf.Abs(rb.velocity.x) > maxSpeedX)
        //{
        //    rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), maxSpeedY * Mathf.Sign(rb.velocity.y));
        //}

        //-----------deslizarse por la pared
        //if (!grounded && wall)
        //{
        //    deslizando = true;
        //}
        //else
        //    deslizando = false;
    }

    private void FixedUpdate()
    {
        //wall = Physics2D.OverlapBox(controladorPared.position, BoxSize, 0f, pared);
        

        //if (deslizando)
        //{
        //    //rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -deslizVelocity, float.MaxValue));
        //    rb.drag += 5f;
        //}

        if(saltar && botonSaltoArriba && coyoteTimeCounter > 0f)
        {
            //jump();
        }

        if(rb.velocity.y < 0 && coyoteTimeCounter < 0f)
        {
            rb.gravityScale = escalarGravedad * multiplicadorGravedad;

            coyoteTimeCounter = 0f;
        }
        else
        {
            rb.gravityScale = escalarGravedad;
        }
        saltar = false;
    }

    public void recoil()
    {
        Vector2 xyVector = new Vector2(pistolaScript.gun.transform.right.x, pistolaScript.gun.transform.right.y);
        xyVector.Normalize();
        
        rb.AddForce(xyVector * - RecoilForce, ForceMode2D.Impulse);
    }

    void ButtonJump()
    {
        if(rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - multiplicadorCancelarSalto), ForceMode2D.Impulse);
        }
        botonSaltoArriba = true;
        saltar = false;
    }

    void jump()
    {
        CreateDust();
        rb.AddForce(Vector2.up * jumpMagnitude, ForceMode2D.Impulse);
        grounded = false;
        saltar = false;
        botonSaltoArriba = false;
    }

    private void Flip()
    {

        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            if (grounded)
            {
                CreateDust();
            }
            
        }
    }

    /*private void Run()
    {
        float targetSpeed = horizontal * MoveSpeed;

        float speedDif = targetSpeed - rb.velocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);
    }*/

    void CreateDust()
    {
        runDust.Play();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(controladorPared.position, BoxSize);
    //}
}