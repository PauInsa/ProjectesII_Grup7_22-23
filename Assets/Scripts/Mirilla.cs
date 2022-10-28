using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class Mirilla : MonoBehaviour
{
    public Transform personaje;
    public int size = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

}