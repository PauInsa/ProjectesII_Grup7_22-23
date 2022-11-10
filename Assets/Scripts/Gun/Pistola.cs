using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform gunHolder;
    public Collider2D pistolCollider;

    public bool isWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWithPlayer)
        {
            pistolCollider.enabled = false;
            //Position respecto Holder
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)gunHolder.position;
            vectorPjMouse.Normalize();
            vectorPjMouse *= 0.8f;
            transform.position = (Vector3)vectorPjMouse + gunHolder.position;
        }
        else
            pistolCollider.enabled = true;
    }
}
