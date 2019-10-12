using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {


	public float chassingSpeed = 5;
	public GameObject playerShip;
	public Transform hunterChild;
	public GameObject ps;
	public float speed = 2;
	public bool onCombat;
	public float counter = 10;
	public float timer = 10;

	private void Start()
	{
		playerShip = GameObject.FindWithTag("Player");
		//hunterChild = GetComponentInChildren<Transform>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Ship" || other.name == gameObject.name)
		{
			Destroy(gameObject);
		}
		if(other.tag == "Player")
		{
			counter = 0;
			onCombat = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			
			onCombat = false;
		}
	}

	private void Update()
	{


		if (counter < timer) counter += Time.deltaTime;
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		if (counter < timer) return;
		transform.LookAt(playerShip.transform);



		/*
		if(gameObject.name == "Hive")
		{
			transform.position = Vector2.MoveTowards(transform.position, playerShip.transform.position, chassingSpeed * Time.deltaTime);

			hunterChild.transform.LookAt(playerShip.transform.position, Vector3.back);
			if (transform.childCount <= 0)
			{
				Destroy(gameObject);
			}
		}

		if(gameObject.tag == "Hive Pack")
		{
			if(GameObject.Find("Queen Hunter") == null)
			{
				Debug.Log("QUEEND DEAD");
			}
			hunterChild.transform.LookAt(playerShip.transform.position, Vector3.back);
		}
		else
		{
			*/




		//transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation,));

		//transform.LookAt(playerShip.transform.position, Vector3.back);
		//transform.position = Vector2.MoveTowards(transform.position, playerShip.transform.position, chassingSpeed * Time.deltaTime);

		//hunterChild.transform.LookAt(playerShip.transform.position, Vector3.back);





		//----------------------------------------------------------------------------------------------------
		//Vector3 diff = playerShip.transform.position - transform.position;

		//float atan2 = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		//hunterChild.transform.localRotation = Quaternion.AngleAxis(atan2, Vector3.right) ; 

		//transform.right = (playerShip.transform.position - hunterChild.transform.position) ;

		//-----------------------------------------------------------------------------------------------------

		//var angle = Mathf.Atan2(playerShip.transform.position.y, playerShip.transform.position.x) * Mathf.Rad2Deg;

		//hunterChild.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

}
