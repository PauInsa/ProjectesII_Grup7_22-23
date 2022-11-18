using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform gunHolder;
    public SpriteRenderer gunRender;
    public Collider2D pistolCollider;
    public Transform gun;

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
            pistolCollider.enabled = false;

            //Position respecto Holder
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)gunHolder.position;
            vectorPjMouse.Normalize();
            vectorPjMouse *= 0.8f;
            transform.position = (Vector3)vectorPjMouse + gunHolder.position;

            direction = mouseWorldPosition - (Vector2)gun.position;
            gun.transform.right = direction;

            //Sprite rotation
            if (mouseWorldPosition.x >= gun.position.x)
                gunRender.flipY = false;
            else
                gunRender.flipY = true;
        }
        else
            pistolCollider.enabled = true;

        
    }
}
