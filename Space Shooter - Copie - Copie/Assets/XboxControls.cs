using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControls : MonoBehaviour {
	public float speed = 5;

	private void Update()
	{
		float deadzone = 0.25f;
		Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (stickInput.magnitude < deadzone)
			stickInput = Vector2.zero;
		else
			stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));

		transform.localPosition = new Vector3(stickInput.x * speed * Time.deltaTime,stickInput.y * speed * Time.deltaTime, 3);
	}

}
