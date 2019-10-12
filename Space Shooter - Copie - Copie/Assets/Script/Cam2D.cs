using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2D : MonoBehaviour {

	public Transform player;

	private void OnEnable()
	{
		player.position = Vector3.zero;

		player.GetComponent<Player2D>().enabled = true;
		player.GetComponent<MouseControls>().enabled = true;
		player.GetComponent<Player3D>().enabled = false;
	}
	private void OnDisable()
	{
		player.GetComponent<MouseControls>().enabled = false;
	}

}
