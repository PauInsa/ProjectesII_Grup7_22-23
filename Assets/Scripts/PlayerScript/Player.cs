using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] hearts;
    int lifes;

    public string Level;

    public AudioSource reciveDamage;

    // Start is called before the first frame update
    void Start()
    {
        lifes = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckLife()
    {
        if (lifes < 1)
        {
            Destroy(hearts[0].gameObject);
            Dead();
        }
        else if (lifes < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (lifes < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (lifes < 4)
        {
            Destroy(hearts[3].gameObject);
        }
    }

    

    public void PlayerDamage(int damage)
    {
        reciveDamage.Play();
        lifes -= damage;
        CheckLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") || collision.CompareTag("BallPlayer"))
        {
            PlayerDamage(1);
        }
    }

    public void Dead()
    {
        SceneManager.LoadScene(Level);
    }
}
