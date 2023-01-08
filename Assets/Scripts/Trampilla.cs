using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampilla : MonoBehaviour
{
    public bool In;

    void Start()
    {
        In = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Gun"))
        {
            In = true;
        }
        else
        {
            In = false;
        }
    }
}
