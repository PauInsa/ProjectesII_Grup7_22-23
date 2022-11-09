using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] hearts;
    int lifes;

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
    }

    void Dead()
    {
        SceneManager.LoadScene("Movimiento perfecto");
    }

    public void PlayerDamage(int damage)
    {
        lifes -= damage;
        CheckLife();
    }
}
