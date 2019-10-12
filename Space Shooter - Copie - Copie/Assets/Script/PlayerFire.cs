using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	[Range(0.05f, 1)]
	public float fireRate = 1;
	float fireTimer;
	public Vector3 lazerAngle;
	public Transform weaponBone;
	public Camera cam;

	[SerializeField] GameObject laserPrefabs;


	void Update ()
	{
		if (fireTimer < fireRate) fireTimer += Time.deltaTime;
		else fireTimer = 0;

		if (Input.GetButton("Fire1") || Input.GetAxis("Axis 10") > 0.1)
		{
			if (fireTimer > 0) return;
			StartFire();
		}

	}


	void StartFire()
	{

		Instantiate(laserPrefabs, weaponBone.position, transform.rotation* Quaternion.Euler( lazerAngle));

	}
}
