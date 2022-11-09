using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    float horizontal = 0.0f;
    float vertical = 0.0f;
    float maxSpeedX;
    float maxSpeedY;
    bool grounded;
    float movementMagnitude = 1.0f;
    float jumpMagnitude;

    public GrabObjects grabObjects;

    

    public Transform personaje;

    public Transform rayOriginTransform;

    public Rigidbody2D rb;

    public bool together;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        grabObjects.grabbedObject = null;
    }

    // Update is called once per frame
    void Update()
    {

        //Comprobar si estan unidos
        if(grabObjects.grabbedObject == null)
        {
            together = false;
        }
        else
        {
            together = true;
        }

        //Mov
        if (!together)
        {
            maxSpeedX = 4.0f;
            maxSpeedY = 31.5f;
            movementMagnitude = 24.0f;
            jumpMagnitude = 54.1f;
        }
        else
        {
            maxSpeedX = 3.0f;
            maxSpeedY = 31.5f;
            movementMagnitude = 16.0f;
            jumpMagnitude = 0.0f;
        }

        //Movimiento
        grounded = Physics2D.Raycast(rayOriginTransform.position, Vector2.down, 0.2f);

            if (Input.GetKey(KeyCode.W))
            {
                
            }
            else if (Input.GetKey(KeyCode.S))
            {

            }
            else if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1.0f;
            }

            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1.0f;
            }
            else
            {
                horizontal = 0.0f;
            }

            //Salto
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        

        rb.AddForce(new Vector2(horizontal * movementMagnitude, 0));

        //if(rb.velocity.x > maxSpeedX || rb.velocity.x <= -maxSpeedX)
        //{
        //    rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        //}

        //if (rb.velocity.y > maxSpeedY || rb.velocity.y <= -maxSpeedY)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, maxSpeedY * Mathf.Sign(rb.velocity.y));
        //}

        if (Mathf.Abs(rb.velocity.y) > maxSpeedY)
            rb.velocity = new Vector2(rb.velocity.x, maxSpeedY * Mathf.Sign(rb.velocity.y));
        else if (Mathf.Abs(rb.velocity.x) > maxSpeedX)
            rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        else if(Mathf.Abs(rb.velocity.y) > maxSpeedY && Mathf.Abs(rb.velocity.x) > maxSpeedX)
        {
            rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), maxSpeedY * Mathf.Sign(rb.velocity.y));
        }


        //Retroceso
        if (together)
        {
            if (Input.GetMouseButtonDown(0))
            {
                recoil();
            }
        }
    }


    void recoil()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)personaje.position;
        Vector2 xyVector = new Vector2(vectorPjMouse.x, vectorPjMouse.y);

        xyVector.Normalize();

        rb.AddForce(xyVector * -4000.0f);
    }

    void jump()
    {
        if (!grounded)
        {
            return;
        }
        else
        {
            rb.AddForce(Vector2.up * jumpMagnitude, ForceMode2D.Impulse);
        }

    }
}