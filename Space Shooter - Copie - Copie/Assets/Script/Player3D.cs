using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour {

	public float moveSpeed = 5;
	public float xSpeed = 5;
	public float ySpeed = 5;
	public GameObject ship;
	public float rotAmp = 0.2f;
	public GameObject xboxOrb;


	private void Update()
	{

		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");


		moveSpeed = Input.GetAxis("Fire2") > 0 ? 80 : 30;




		transform.Translate(Vector3.forward*(moveSpeed * Time.deltaTime));


		transform.Rotate(y, 0, x);

		//transform.Rotate(xboxOrb.transform.position);

		//transform.Rotate(new Vector3(stickInput.y, 0, stickInput.x));

		//transform.Rotate(new Vector3(-y * ySpeed *Time.deltaTime, 0, -x * xSpeed * Time.deltaTime));

		ship.transform.localRotation = Quaternion.Euler(new Vector3(y*ySpeed, 0, x*xSpeed));

	}


}
