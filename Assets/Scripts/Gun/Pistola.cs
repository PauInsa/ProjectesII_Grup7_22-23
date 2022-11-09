using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform personaje;
    public Collider2D pistolCollider;

    private bool isWithPlayer;
    private int size;

    public Transform pistolaTransform;
    public SpriteRenderer pistolaRenderer;

    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = true;
        size = 1;
        pistolCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Sprite rotation
        Vector3 targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
        pistolaTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 90 || angle < -90)
        {

            pistolaRenderer.flipY = true;
        }
        else
        {
            pistolaRenderer.flipX = true;
        }

        //Input
        if(Input.GetMouseButton(0))
        {
            //Shoot
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shootDirection = mouseWorldPosition - personaje.position;

        }
        else if(Input.GetMouseButton(1))
        {
            //Reload
        }

       if (isWithPlayer)
        {
            //Position respecto Player
            if (size <= 0) return;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 vectorPjMouse = mouseWorldPosition - personaje.position;
            Vector3 xyVector = new Vector3(vectorPjMouse.x, vectorPjMouse.y, 0.0f);
            float vectorSize = xyVector.magnitude;
            if (vectorSize > size)
            {
                xyVector.Normalize();
                xyVector *= size;
                vectorSize = size;
            }
            transform.position = xyVector + personaje.position;
        }
        else
        {

        }
        
    }

    void SwitchPistolState()
    {
        isWithPlayer = !isWithPlayer;
        pistolCollider.enabled = !isWithPlayer;
    }

    /*void Shoot()
    {
        GameObject goBullet = Instantiate(bullet, gun.position, Quaternion.identity);
        LinearMovement bulletMovement = goBullet.GetComponent<LinearMovement>();

        if (spriteRenderer.flipX == false)
        {
            bulletMovement.SetDirection(Vector3.left);
        }
        else
            bulletMovement.SetDirection(Vector3.right);



        bool collides = false;

        if (collides == true)
        {
            Destroy(goBullet);
        }
    }*/
}
