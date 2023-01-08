using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootRange : MonoBehaviour
{
    public bool isColliding;
    public string Tag;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag))
        {
            isColliding = true;
        }
        else
            isColliding = false;
    }
}
