using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemieFollow : MonoBehaviour
{
    public Transform player_pos;
    public float speed;
    public float distancia_frenado;
    public float huir;

    void Start()
    {
        player_pos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //Mov
        if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado)
        {
            transform.position = Vector2.MoveTowards(transform.position, player_pos.position, speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, player_pos.position) < huir)
        {
            transform.position = Vector2.MoveTowards(transform.position, player_pos.position, -speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player_pos.position) < huir && Vector2.Distance(transform.position, player_pos.position) > distancia_frenado)
        {
            transform.position = transform.position;
        }

        //Flip
        if(player_pos.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this.transform.localScale = new Vector2(-1, 1);
        }

    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Amo"))
        {
            Destroy(this);
        }
    }
}
