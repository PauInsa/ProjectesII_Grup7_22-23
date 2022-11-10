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
    public AudioSource fireSound, reloadSound;

    public GameObject bullet;
    public float bulletSpd;
    public float fireRate;
    public float dissapearTime;
    public float reloadTime;
    float deltaTimeFire;

    public int ammo;

    bool reloading;
    float deltaTimeReload;


    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
        reloading = false;
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
            if (ammo > 0 && reloading == false)
            {
                if (Time.time > deltaTimeFire)
                {
                    recoil();
                    if (movScript.together == true)
                        movScript.recoil();

                    deltaTimeFire = Time.time + 1 / fireRate;
                    GameObject goBullet = Instantiate(bullet, gun.position, shootPoint.rotation);
                    goBullet.transform.right = direction;
                    goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                    Destroy(goBullet, dissapearTime);

                    ammo--;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
            reload();

        //Sprite rotation
        if (mouseWorldPosition.x >= gun.position.x)
            gunRender.flipY = false;
        else
            gunRender.flipY = true;

        //Reload
        if (reloading == true)
        {
            reloadSound.Play();
            if (Time.time > reloadTime + deltaTimeReload)
            {
                ammo = 10;
                reloading = false;
            }
        }
    }
    void recoil()
    {
        fireSound.Play();
        Vector2 xyVector = new Vector2(direction.x, direction.y);
        xyVector.Normalize();
        rb.AddForce(xyVector * -1500.0f);
    }
    void reload()
    {
        if (reloading == false && ammo !=10)
        {
            reloading = true;
            deltaTimeReload = Time.time;
        }
    }
}


