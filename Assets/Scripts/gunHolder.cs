using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHolder : MonoBehaviour
{

    public Transform player;
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        size = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Position respecto Player
        if (size <= 0) return;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)player.position;
        vectorPjMouse.Normalize();
        vectorPjMouse *= size;
        transform.position = (Vector3)vectorPjMouse + player.position;
    }
}
