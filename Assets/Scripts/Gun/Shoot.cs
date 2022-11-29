using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Mov movScript;

    public Transform gun;
    public Rigidbody2D rb;

    public AudioSource fireSound;

    public Transform shootPoint;
    public GameObject bullet;
    public float bulletSpd;

    public bool grounded;
    public float gunTorque;
    public float recoilForce;
    public float fireRate;
    float deltaTimeFire;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Raycast(gun.position, Vector2.down, 0.4f, LayerMask.GetMask("Walls"));

        if (Input.GetMouseButtonDown(0) && Time.time > deltaTimeFire)
        {
            if (movScript.together == true)
                movScript.recoil();
            else
                recoil();

            deltaTimeFire = Time.time + 1 / fireRate;
            GameObject goBullet = Instantiate(bullet, gun.position, shootPoint.rotation);
            goBullet.transform.right = gun.transform.right;
            goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);

            fireSound.Play();
        }
        if (Input.GetMouseButtonDown(1) && grounded == true)
        {
            FlipGun();
        }
    }
    void recoil()
    {
        Vector2 xyVector = new Vector2(gun.transform.right.x, gun.transform.right.y);
        xyVector.Normalize();
        rb.AddForce(xyVector * recoilForce);
        rb.AddTorque(gunTorque, ForceMode2D.Impulse);
    }
    void FlipGun()
    {
        rb.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
        rb.AddTorque(gunTorque, ForceMode2D.Impulse);
    }
}


