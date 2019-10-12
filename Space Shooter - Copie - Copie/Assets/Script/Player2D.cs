using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

	float xMin, xMax, yMin, yMax;

	int rotation;

	void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

	void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var x = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var y = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

		 transform.position = new Vector3(x, y);

		float joyX = Input.GetAxis("Joystick X");
		float joyY = Input.GetAxis("Joystick Y");

		//float targetRotation = Mathf.Atan2(joyX, -joyY) * Mathf.Rad2Deg;

		//transform.rotation = Quaternion.Euler( 0, 0, -targetRotation);


		//------------------------------------- Input Based -------------------------------------------
		/*
				if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
				{
					float targetRotation = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg;

					transform.rotation = Quaternion.Euler(0, 0, -targetRotation);
				}

		//---------------------------------------------------------------------------------------------

			*/

	}
}
