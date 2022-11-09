using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gun;
    Vector2 direction;
    public GameObject bullet;
    public float bulletSpd;
    public Transform shootPoint;


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

        if (Input.GetMouseButton(0))
        {
            //Shoot
            GameObject goBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right*bulletSpd);
        }
    }
}
