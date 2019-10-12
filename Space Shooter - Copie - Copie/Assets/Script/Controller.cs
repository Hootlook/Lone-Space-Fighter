using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	Camera cam;

	private void Start()
	{
		cam = GetComponentInParent<Camera>();
	}

	void Update () {


		float y = Input.GetAxis("Joystick Y");
		float x = Input.GetAxis("Joystick X");

		transform.Translate(new Vector2(x, y));


		Vector3 pos = cam.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = cam.ViewportToWorldPoint(pos);
	
	}
}
