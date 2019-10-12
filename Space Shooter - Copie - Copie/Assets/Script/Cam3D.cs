using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam3D : MonoBehaviour {

	public Transform player;
	Skybox sb;
	Camera cam;
	public float z = 6;
	public float w = 5f;
	public float t = 0.01f;
	public float fov = 50;
	float xv;
	float yv;


	private void Start()
	{
		sb = GetComponent<Skybox>();
		cam = gameObject.GetComponent<Camera>();
		//sb.material.shader = Shader.Find("Skybox/StartNest");
	}

	private void Update()
	{
		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");


		transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 1, -6), 0.1f);
		transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Vector3.zero),0.1f);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, GetComponentInParent<Player3D>().moveSpeed+10, t);

		//Vector4 val = new Vector4(x, x, x, w);


		//	sb.material.SetFloat("_Brightness", o);

		//transform.rotation = Quaternion.Euler(y, x, 0);//Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(y, x)*3),t);
		//transform.position = Vector3.Lerp(transform.position, player.position - Vector3.forward * 3, t);

		//sb.material.SetVector("_Rotation",val);
		//sb.material.SetVector("_Scroll", new Vector4());
	}
	/*
		private void OnEnable()
		{
			transform.position = new Vector3(0, -3, -0.5f);
			player.position = Vector3.zero;
			player.rotation = Quaternion.Euler(Vector3.zero);

			player.GetComponent<Player2D>().enabled = false;
			player.GetComponent<Player3D>().enabled = true;
		}
		*/

}
