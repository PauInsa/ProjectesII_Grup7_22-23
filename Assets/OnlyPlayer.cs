using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPlayer : MonoBehaviour
{
    public Pistola Pistola;
    public PointEffector2D PointEffector2D;
    public bool enterzone = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enterzone = true;
            PointEffector2D.forceMagnitude = 0;
        }

        else if (collision.transform.CompareTag("Gun"))
        {
            PointEffector2D.forceMagnitude = 300;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (enterzone == true && Pistola.isWithPlayer == true)
        {
            PointEffector2D.forceMagnitude = 500;
        }
    }
}
