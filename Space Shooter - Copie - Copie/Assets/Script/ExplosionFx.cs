using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFx : MonoBehaviour {

	GameObject ps;
	public string FXname = "%ParticleSystem's Name%";
	

	private void Awake()
	{
		ps = GameObject.Find(FXname);
	}

	private void OnDestroy()
	{
		if (ps == null) return;
		ps.transform.position = transform.position;
		ps.GetComponent<ParticleSystem>().Play();
		ps.GetComponent<AudioSource>().Play();
	}
}
