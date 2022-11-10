using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform gun;

    public Transform shootPoint;

    public AudioSource fireSound;

    public Transform player_pos;


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
        //Direccion de bala
        Vector2 vectorEnemiePJ = (Vector2)player_pos.position - (Vector2)shootPoint.position;
        //Vector2 xyVector = new Vector2(vectorPjMouse.x, vectorPjMouse.y);

        vectorEnemiePJ.Normalize();

       if (Time.time > deltaTime)
       {
                fireSound.Play();
                deltaTime = Time.time + 1 / fireRate;
                GameObject goBullet = Instantiate(bullet, gun.position, shootPoint.rotation);
                goBullet.transform.right = vectorEnemiePJ;
                goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                Destroy(goBullet, dissapearTime);
            
        }
    }
}
