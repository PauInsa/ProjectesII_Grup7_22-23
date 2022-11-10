using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Mov movScript;

    public Transform gun;
    public SpriteRenderer gunRender;
    Vector2 direction;

    public Transform shootPoint;
    public Rigidbody2D rb;
    public AudioSource fireSound;

    public GameObject bullet;
    public float bulletSpd;
    public float fireRate;
    public float dissapearTime;
    float deltaTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mouseWorldPosition - (Vector2)gun.position;
        gun.transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            //Shoot

            if(Time.time > deltaTime)
            {
                recoil();
                if (movScript.together == true)
                    movScript.recoil();

                deltaTime = Time.time + 1 / fireRate;
                GameObject goBullet = Instantiate(bullet, gun.position, shootPoint.rotation);
                goBullet.transform.right = direction;
                goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                Destroy(goBullet, dissapearTime);
            }
            
        }

        //Sprite rotation
        if (mouseWorldPosition.x >= gun.position.x)
            gunRender.flipY = false;
        else
            gunRender.flipY = true;

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


