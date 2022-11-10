using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform gunHolder;
    public Collider2D pistolCollider;

    private bool isWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = true;
        pistolCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        if (Input.GetMouseButton(0))
        {
            //Shoot


        }
        else if (Input.GetMouseButton(1))
        {
            //Reload
        }

        if (isWithPlayer)
        {
            //Position respecto Holder
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)gunHolder.position;
            vectorPjMouse.Normalize();
            vectorPjMouse *= 0.8f;
            transform.position = (Vector3)vectorPjMouse + gunHolder.position;
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
}
