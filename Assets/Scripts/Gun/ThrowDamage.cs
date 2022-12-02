using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDamage : MonoBehaviour
{

    public Enemys enemies;

    public Rigidbody2D rb;
    
    public Shoot ShootScript;
    public Pistola pistolaScript;

    public int hitPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (pistolaScript.isWithPlayer == true)
            return;

        if (collision.transform.CompareTag("Enemy"))
        {

            enemies.EnemyDamage(hitPoint);

            ShootScript.recoil();

            //Vector2 xyVector = new Vector2(gun.transform.right.x, gun.transform.right.y);
            //xyVector.Normalize();
            //rb.AddForce(xyVector * recoilforce);
            //rb.AddTorque(torque, ForceMode2D.Impulse);
        }
    }
}
