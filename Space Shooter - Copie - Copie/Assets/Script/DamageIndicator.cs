using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour {

	Renderer m;
	[HideInInspector]
	public float hit = 100;
	public float speed = 2;


	private void Start()
	{
		m = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		if (hit < 100) hit++;

		var color = Color.Lerp(Color.red, Color.white, hit * speed * Time.deltaTime); 

		m.material.color = color;

		//transform.position = Vector3.left* Mathf.Sin(Time.time * speed) * amount;
	}

}
