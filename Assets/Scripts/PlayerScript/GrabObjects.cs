using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public Pistola pistolaScript;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private float rayDistance = 0f;

    [SerializeField]
    private Transform PlayerAimDirection;

    public GameObject gun;
    private int layerIndex;

    public float forceThrow = 0f;
    

    // Start is called before the first frame update
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, Vector2.right*transform.localScale.x, rayDistance);

        if(hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            //grab object
            pistolaScript.isWithPlayer = true;
        }

        if (Input.GetKeyDown(KeyCode.B) && pistolaScript.isWithPlayer ==true)
        {
            pistolaScript.isWithPlayer = false;
            gun.GetComponent<Rigidbody2D>().isKinematic = false;
            Vector2 xyvector = new Vector2(PlayerAimDirection.localScale.x, PlayerAimDirection.localScale.y);
            xyvector.Normalize();
            gun.GetComponent<Rigidbody2D>().AddForce(xyvector * forceThrow, ForceMode2D.Impulse);
            gun.transform.SetParent(null);
        }
        //Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
