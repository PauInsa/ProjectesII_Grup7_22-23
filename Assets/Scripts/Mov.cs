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

    public bool equipedWeapon;

    public Transform rayOriginTransform;

    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //Comprobar si estan juntos
        if (equipedWeapon)
        {
            maxSpeedX = 3.0f;
            maxSpeedY = 31.5f;
            movementMagnitude = 16.0f;
            jumpMagnitude = 0.0f;
        }
        else
        {
            maxSpeedX = 4.0f;
            maxSpeedY = 31.5f;
            movementMagnitude = 24.0f;
            jumpMagnitude = 54.1f;
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
        if (Mathf.Abs(rb.velocity.x) > maxSpeedX)
            rb.velocity = new Vector2(maxSpeedX * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) > maxSpeedY)
            rb.velocity = new Vector2(rb.velocity.x, maxSpeedY * Mathf.Sign(rb.velocity.y));

        if(Input.GetKeyDown(KeyCode.B))
        {
            if (equipedWeapon == false)
                equipedWeapon = true;
            else
                equipedWeapon = false;
        }
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