using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyStalker;
    public GameObject enemySniper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
