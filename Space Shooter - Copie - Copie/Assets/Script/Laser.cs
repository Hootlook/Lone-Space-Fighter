using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    Rigidbody rb;
    public float fireSpeed = 5;
	public GameObject shooter;

	void Start () {
        rb = GetComponent<Rigidbody>();
		shooter = GameObject.FindGameObjectWithTag("Player");
		rb.velocity = shooter.GetComponent<Rigidbody>().velocity + (transform.up * (fireSpeed + shooter.GetComponent<Player3D>().moveSpeed));
	}
	
	void Update () {

		
		//rb.velocity = transform.up * fireSpeed ;

		Destroy(gameObject, 5);
	}

	private void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponentInParent<Health>().health--;
		if (other.gameObject.GetComponent<Health>().health == 0)
		{
			if (other.gameObject.tag == "Asteroid")
			{
				GameObject.Find("MANAGER").GetComponent<manager>().score += 200;
			}
			if (other.gameObject.GetComponentInChildren<GameObject>().tag == "Enemy")
			{
				GameObject.Find("MANAGER").GetComponent<manager>().score += 400;
			}

		}
		Destroy(gameObject);

	}
}
