using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        Vector2 pistolpos = transform.position;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousepos - pistolpos;
        transform.right = direction;

        if(mousepos.x < pistolpos.x)
        {
            //spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }
        else if(mousepos.x > pistolpos.x)
        {
            //spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }
    }
}