using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trajectoria : MonoBehaviour
{
    public GameObject point;
    GameObject[] pointsList;
    public int numPoints;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numPoints; i++)
        {
            pointsList[i] = point;
            point.transform.localScale -= new Vector3(1, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
