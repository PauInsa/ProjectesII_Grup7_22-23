using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public float speedMagnitude;
    public float rayLength;
    public Collider2D bulletCollider;
    public Transform bulletTransform;
    Vector3 direction;

    private void Update()
    {
        transform.position += direction * speedMagnitude * Time.deltaTime;
        if (Physics2D.Raycast(bulletTransform.position, direction, rayLength))
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDirection(Vector3 value)
    {
        direction = value;
    }
}
