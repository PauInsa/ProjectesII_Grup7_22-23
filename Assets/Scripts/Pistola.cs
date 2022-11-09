using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform personaje;
    public Collider2D pistolCollider;

    private bool isWithPlayer;
    private float size;

    public Transform pistolaTransform;
    public SpriteRenderer pistolaRenderer;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = true;
        size = 0.7f;
        pistolCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Sprite rotation
        if (angle.eulerAngles.z > 90 || angle.eulerAngles.z < -90)
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
            

        }
        else if(Input.GetMouseButton(1))
        {
            //Reload
        }

        if (isWithPlayer)
        {
            //Position respecto Player
            if (size <= 0) return;
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)personaje.position;
            vectorPjMouse.Normalize();
            vectorPjMouse *= size;
            transform.position = (Vector3)vectorPjMouse + personaje.position;
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
