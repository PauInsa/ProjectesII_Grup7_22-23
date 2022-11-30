using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDamage : MonoBehaviour
{

    public Enemys enemies;

    public int hitPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {

            enemies.EnemyDamage(hitPoint);
        }
    }
}
