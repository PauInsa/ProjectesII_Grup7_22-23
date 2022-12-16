using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    Interpolator aimToCursor;
    public float aimDelayTime;
    bool isAiming;

    public Transform gunHolder;
    public SpriteRenderer gunRender;
    public Transform gun;

    public Collider2D gunCollider;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 direction;

    public float holderDistance;
    public float aimHeight;
    public bool isWithPlayer;

    public float angularDrag;
    public float linearDrag;

    Vector2 mouseWorldPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = false;
        isAiming = false;
        aimToCursor = new Interpolator(aimDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isWithPlayer)
        {

            //Position respecto Holder
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)gunHolder.position;
            vectorPjMouse.Normalize();
            vectorPjMouse *= holderDistance;
            transform.position = (Vector3)vectorPjMouse + gunHolder.position;

            //Sprite rotation
            if (mouseWorldPosition.x >= gun.position.x)
                gunRender.flipY = false;
            else
                gunRender.flipY = true;
        }


    }

    public void FixedUpdate()
    {
        //if(!Physics2D.Raycast(gun.position, Vector2.down, aimHeight, LayerMask.GetMask("Walls")) && aimToCursor.IsMinPrecise)
        //{
        //    aimToCursor.ToMax();

        //    Vector2 aimingDirection = (Vector2)gun.position + (mouseWorldPosition - 2 * (Vector2)gun.position) * aimToCursor.Value;
        //    Quaternion aimingRotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 90f) * aimingDirection);
        //    rb.SetRotation(aimingRotation);

        //    if (aimToCursor.IsMaxPrecise)
        //        isAiming = true;
        //}
        //else
        //    isAiming = false;

        if (isWithPlayer == true || !Physics2D.Raycast(gun.position, Vector2.down, aimHeight, LayerMask.GetMask("Walls"))/*|| isAiming == true*/)
        {
            direction = mouseWorldPosition - (Vector2)gun.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0,0,90f) * direction);
            rb.SetRotation(rotation);
        }
    }

    public void Grab()
    {
        rb.isKinematic = true;
        gunCollider.enabled = false;
        rb.drag = 0;
        rb.angularDrag = 0;
        isWithPlayer = true;
        animator.SetBool("WithPlayer", true);
    }

    public void Throw(float forceThrow)
    {
        rb.isKinematic = false;
        gunCollider.enabled = true;
        rb.drag = linearDrag;
        rb.angularDrag = angularDrag;
        isWithPlayer = false;
        animator.SetBool("WithPlayer", false);

        //Add force to throw the gun
        GetComponent<Rigidbody2D>().AddForce(transform.right * forceThrow, ForceMode2D.Impulse);
    }
}
