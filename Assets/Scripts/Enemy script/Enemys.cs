using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public int lifes;
    public Transform enemy;

    private void Start()
    {
        
    }

    void Update()
    {
        if (lifes < 1)
        {
            
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BallPlayer"))
        {
            EnemyDamage(1);
        }
    }

    public void EnemyDamage(int damage)
    {
        //reciveDamage.Play();
        lifes -= damage;
    }
}
