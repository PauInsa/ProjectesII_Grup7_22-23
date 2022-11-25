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

    [SerializeField]
    private Transform shotPoint;

    private int layerIndex;

    public float forceThrow = 0f;

    public LayerMask grabbableObjectsLayers;

    float grabDelay = 0f;

    public float grabThreshold = 0.2f;

    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(this.transform.position, 0.5f, grabbableObjectsLayers);

        grabDelay += Time.deltaTime;

        if(col != null && grabDelay > grabThreshold)
            pistolaScript.Grab();

        if (Input.GetKeyDown(KeyCode.B) && pistolaScript.isWithPlayer == true)
        {
            grabDelay = 0f;
            pistolaScript.Throw(forceThrow);
        }
    }

}
