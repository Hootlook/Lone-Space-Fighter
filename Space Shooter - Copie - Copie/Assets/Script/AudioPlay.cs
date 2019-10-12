using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioPlay : MonoBehaviour {

	public GameObject ship;
	public Camera cam;

	private void Update()
	{
		ship.GetComponent<AudioSource>().pitch = (cam.fieldOfView/100)+0.5f;
	}

}
