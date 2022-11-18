using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject BalaFather;
    public GameObject player;
    public GameObject enemyStalker;
    public GameObject enemySniper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(BalaFather);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(BalaFather);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(BalaFather);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(BalaFather);
        }
    }


}
