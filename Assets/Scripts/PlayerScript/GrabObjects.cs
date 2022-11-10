using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private float rayDistance = 0f;

    [SerializeField]
    private Transform PlayerAimDirection;

    public GameObject grabbedObject;
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
            if(Input.GetKeyDown(KeyCode.B) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }

            //release object
            else if (Input.GetKeyDown(KeyCode.B))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                Vector2 xyvector = new Vector2(PlayerAimDirection.localScale.x, PlayerAimDirection.localScale.y);
                xyvector.Normalize();
                grabbedObject.GetComponent<Rigidbody2D>().AddForce(xyvector * forceThrow, ForceMode2D.Impulse);
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        
    }
}
