using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [Header("Particles")]
    public ParticleSystem damageParticle;

    [Header ("Lifes")]
    public int lifes;

    [Header("Color")]
    public SpriteRenderer renderer;
    public Color originalColor;
    public Color damageColor;
    public float DamageTime;

    float timer;


    void start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (lifes < 1)
        {
            Destroy(gameObject);
        }

        //Contador color
        if(timer <= 0)
        {
           renderer.color = originalColor;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BallPlayer"))
        {
            EnemyDamage(1);

            damageParticle.Play();

            //Le damos el nuevo color al objeto
            renderer.color = damageColor;
            timer = DamageTime;
        }
    }

    public void EnemyDamage(int damage)
    {
        //reciveDamage.Play();
        lifes -= damage;
    }

}
