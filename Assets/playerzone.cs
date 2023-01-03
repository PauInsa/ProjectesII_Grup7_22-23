using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerzone : MonoBehaviour
{
    public Pistola pistola;
    public PointEffector2D PointEffector2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PointEffector2D.forceMagnitude = 0;
        }
        else
            PointEffector2D.forceMagnitude = 700;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && pistola.isWithPlayer)
        {
            PointEffector2D.forceMagnitude = 700;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
