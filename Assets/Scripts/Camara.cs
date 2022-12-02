using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
	public GameObject follow;
	public Vector2 minCampPos, maxCampPos;
	public float smoothTime;

	private Vector2 velocity;

	void FixedUpdate()
	{
		float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
		float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

		transform.position = new Vector2
			(Mathf.Clamp(posX, minCampPos.x, maxCampPos.x),
			Mathf.Clamp(posY, minCampPos.y, maxCampPos.y));
	}


}
