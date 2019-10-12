using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHunter : MonoBehaviour {

	public Transform playerShip;

	public float speed = 2;

	private void Update()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * playerShip.transform.rotation.eulerAngles.z), 1);

		transform.LookAt(playerShip, Vector3.back);
	}
}
