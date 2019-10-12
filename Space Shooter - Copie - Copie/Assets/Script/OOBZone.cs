using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBZone : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boulder") return;
		other.transform.position = other.GetComponent<Asteroid>().startPos;
	}

}
