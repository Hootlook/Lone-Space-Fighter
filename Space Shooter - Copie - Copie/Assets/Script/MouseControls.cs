﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour {

	void Update () {
		//----------------------------------- Mouse Based ---------------------------------------------



		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		difference.Normalize();

		float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);
	}
}
