using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public int lifes;

    
    void Update()
    {
        if (lifes < 1)
        {
            Destroy(gameObject);
        }

    }

    public void PlayerDamage(int damage)
    {
        //reciveDamage.Play();
        lifes -= damage;
    }
}
