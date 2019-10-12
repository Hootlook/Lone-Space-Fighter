using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class manager : MonoBehaviour {

    public GameObject player;
	[Header("CameraSwitch")]
	public GameObject POOL;
	public GameObject cam;
	public GameObject scoreTab;
	public GameObject title;
	public GameObject helpText;
	public GameObject HUD;
	public bool cameraMode = true;
	public bool startPressed = false;
	public bool hasntStarted = true;
	float time = 100;
	bool startTime = false;
	public int score;

	private void Start()
	{
		POOL.SetActive(false);
	}

	private void Update()
    {

		scoreTab.GetComponent<TextMeshProUGUI>().text = "Score: " + score;

		if(startTime == true)
		{
			time += 1.2f * 1.2f * 1.2f;
		}
		
		
		if(startPressed == true)
		{
			startGame();
		}


		cam.GetComponent<MenuCam>().enabled = cameraMode;
		cam.GetComponent<Cam3D>().enabled = !cameraMode;
		if (hasntStarted == false) return;
		if (Input.GetButtonDown("Submit"))
		{
			startPressed = true;
			cameraMode = !cameraMode;
			GetComponentInChildren<AudioSource>().Play();
			GetComponent<AudioSource>().Play();
			startTime = true;
			hasntStarted = false;
		}
	}

	private void startGame()
	{
		title.SetActive(false);
		helpText.SetActive(false);
		cam.GetComponent<Camera>().fieldOfView = time*0.3f;
		cam.GetComponent<Skybox>().material.SetFloat("_Iterations", time/14);
		cam.GetComponent<Skybox>().material.SetVector("_Center",new Vector3(1,1,(1 * time) / 14));
		if (cam.GetComponent<Camera>().fieldOfView < 170) return;
		cam.GetComponent<Skybox>().material.SetFloat("_Iterations", 16.6f);
		cam.GetComponent<Skybox>().material.SetVector("_Center", Vector3.one);
		player.GetComponent<Player3D>().enabled = !player.GetComponent<Player3D>().enabled;
		HUD.SetActive(true);
		POOL.SetActive(true);
		startPressed = false;
	}


}
