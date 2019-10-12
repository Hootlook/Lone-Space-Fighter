using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour {

	public ParticleSystem ps;
	public GameObject GameOverText;
	public GameObject HelpText;
	public GameObject heathBar;
	public GameObject ship;
	bool doOnce = false;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			//Debug.Log("PLAYER DIED TO COLLISION WITH ENNEMY");
			GetComponent<Health>().health -= 1;
			Destroy(collision.transform.parent.gameObject);
		}
		if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Boulder")
		{
			GetComponent<Health>().health -= 1;
			Destroy(collision.gameObject);
		}


		if(collision.gameObject.tag == "Ship")
		{
			GetComponent<Health>().health = 0;
		}
	}

	private void Update()
	{
	
		heathBar.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<Health>().health * 20,100);
		if (GetComponent<Health>().health <= 0)
		{
			gameover();
			if (Input.GetButtonDown("Cancel"))
			{
				SceneManager.LoadScene("MainScene");
				SceneManager.LoadScene("MainScene");
			}
		}
	}

	void gameover()
	{
		if (doOnce) return;
		GetComponent<Player3D>().enabled = false;
		GetComponent<PlayerFire>().enabled = false;
		GetComponent<BoxCollider>().size = Vector3.one *10;
		GameOverText.SetActive(true);
		HelpText.SetActive(true);
		GameObject.Find("MANAGER").GetComponent<manager>().cameraMode = !GameObject.Find("MANAGER").GetComponent<manager>().cameraMode;
		GameObject.Find("MANAGER").GetComponent<AudioSource>().Stop();
		ps.gameObject.transform.position = transform.position;
		ps.gameObject.GetComponent<AudioSource>().Play();
		ps.Play(true);
		ship.SetActive(false);
		GameObject.Find("AudioManager").GetComponent<AudioSource>().Play();
		doOnce = true;
	}
}
