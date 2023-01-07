using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public int lifes;
    public Transform enemy;
    public ParticleSystem particle;

    private void Start()
    {
        
    }

    void Update()
    {
        if (lifes <= 0)
        {
            
            //Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (lifes == 0)
        {
            Corpse();
            lifes = -1;
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

    private void Corpse()
    {
        particle.Play();

        Vector2 impulse = new Vector2(15.0f, 45.0f);
        impulse.Normalize();
        GetComponent<Rigidbody2D>().AddForce(impulse * 4, ForceMode2D.Impulse);

        Vector3 asdd = new Vector3(0, 0, -90f);
        GetComponent<Transform>().Rotate(asdd);
    }
}
