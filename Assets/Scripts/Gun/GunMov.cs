using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMov : MonoBehaviour
{
    public Mov player;
    public Transform gun;
    public Rigidbody2D rb;

    public AudioSource fireSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!player.together)
        {
            if (Input.GetMouseButtonDown(0))
            {
                recoil();
            }
        }

        void recoil()
        {
            fireSound.Play();       
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vectorPjMouse = mouseWorldPosition - (Vector2)gun.position;
            Vector2 xyVector = new Vector2(vectorPjMouse.x, vectorPjMouse.y);

            xyVector.Normalize();

            rb.AddForce(xyVector * -1500.0f);
        }
    }
}
