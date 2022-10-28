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
    Vector3 targetRotation;
    Vector3 finalTarget;

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
        targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
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

       if (isWithPlayer)
        {
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
}
