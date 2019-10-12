using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLerp : MonoBehaviour {

	public Transform t;
	public float lerpSpeed = 0.5f;



	void Update () {


		if (t != null)
      
		transform.rotation = Quaternion.Slerp(transform.rotation, t.rotation , lerpSpeed);
	}
}
