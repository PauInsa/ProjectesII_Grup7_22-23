using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform gunHolder;
    public SpriteRenderer gunRender;
    public Transform gun;

    public Collider2D gunCollider;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 direction;

    public bool isWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isWithPlayer)
        {

            //Position respecto Holder
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)gunHolder.position;
            vectorPjMouse.Normalize();
            vectorPjMouse *= 0.4f;
            transform.position = (Vector3)vectorPjMouse + gunHolder.position;

            direction = mouseWorldPosition - (Vector2)gun.position;
            gun.transform.right = direction;

            //Sprite rotation
            if (mouseWorldPosition.x >= gun.position.x)
                gunRender.flipY = false;
            else
                gunRender.flipY = true;
        }
    }

    public void Grab()
    {
        rb.isKinematic = true;
        gunCollider.enabled = false;
        isWithPlayer = true;
        animator.SetBool("WithPlayer", true);
    }

    public void Throw(float forceThrow)
    {
        rb.isKinematic = false;
        gunCollider.enabled = true;
        isWithPlayer = false;
        animator.SetBool("WithPlayer", false);

        //Add force to throw the gun
        GetComponent<Rigidbody2D>().AddForce(transform.right * forceThrow, ForceMode2D.Impulse);
    }
}
