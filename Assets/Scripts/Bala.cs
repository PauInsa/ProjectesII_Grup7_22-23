using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyStalker;
    public GameObject enemySniper;

    public ParticleSystem particleSystem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            particleSystem.Play();
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

    }
}
