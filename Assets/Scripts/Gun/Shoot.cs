using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gun;
    public SpriteRenderer gunRender;
    Vector2 direction;
    public GameObject bullet;
    public Transform shootPoint;

    public float bulletSpd;
    public float fireRate;
    public float dispearTime;
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
                deltaTime = Time.time + 1/fireRate;
                GameObject goBullet = Instantiate(bullet, gun.position, shootPoint.rotation);
                goBullet.transform.right = direction;
                goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                Destroy(goBullet, dispearTime);
            }

        }

        //Sprite rotation
        if (mouseWorldPosition.x >= gun.position.x)
        {

            gunRender.flipY = true;
        }
        else
        {
            gunRender.flipY = false;
        }
    }
}
