using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float maxSpeedX;
    public float maxSpeedY;
    bool grounded;
    public float movementMagnitude;
    public float jumpMagnitude;
    bool isFacingRight = true;

    public float inicialDrag;

    public float multiplicadorCancelarSalto;
    public float multiplicadorGravedad;
    private float escalarGravedad;
    private bool botonSaltoArriba = true;
    private bool saltar;

    public float coyoteTime;
    private float coyoteTimeCounter;


    public Pistola pistolaScript;

    public AudioSource fireSound;

    public Transform personaje;

    public Transform rayOriginTransform;

    public Rigidbody2D rb;

    public bool together = false;

    private bool A_Up;
    private bool D_Up;

    private float tiempoA_UP = 0.2f;
    private float tiempoD_UP = 0.2f;

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
            Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            D_Up = false;
            horizontal = 1.0f;
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
            if(rb.drag < 8)
                rb.drag += 1f;
        }
        else if(!D_Up && tiempoA_UP > 0 && grounded) //Estabas yendo hacia la izquierda y justo has cambiado de direccion
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
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
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
            BottonJump();
            A_Up = true;
            D_Up = true;
        }


        rb.AddForce(new Vector2(horizontal * movementMagnitude, 0));

        if (Mathf.Abs(rb.velocity.y) > maxSpeedY)
            rb.velocity = new Vector2(rb.velocity.x, maxSpeedY * Mathf.Sign(rb.velocity.y));
        else if (Mathf.Abs(rb.velocity.x) > maxSpeedX)
            rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        else if(Mathf.Abs(rb.velocity.y) > maxSpeedY && Mathf.Abs(rb.velocity.x) > maxSpeedX)
        {
            rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), maxSpeedY * Mathf.Sign(rb.velocity.y));
        }


    }

    private void FixedUpdate()
    {
        if(saltar && botonSaltoArriba && coyoteTimeCounter > 0f)
        {
            jump();
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
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)personaje.position;
        Vector2 xyVector = new Vector2(vectorPjMouse.x, vectorPjMouse.y);

        xyVector.Normalize();

        rb.AddForce(xyVector * -4000.0f);
    }

    void BottonJump()
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
        }
    }
}