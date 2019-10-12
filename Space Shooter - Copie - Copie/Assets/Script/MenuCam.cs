using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour {

	public float speed = 1;
	float velocity;
	public Transform player;



	void Update ()
	{

		velocity = speed * Time.deltaTime;

		transform.LookAt(player, Vector3.up);
		transform.Translate(Vector3.right* velocity);

	}

}
