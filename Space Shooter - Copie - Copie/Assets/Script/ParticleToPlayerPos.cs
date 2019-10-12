using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToPlayerPos : MonoBehaviour {

	public Transform t;


	void Update () {
		transform.position = t.position;
	}
}
