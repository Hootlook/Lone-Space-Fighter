using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class god : MonoBehaviour {

	public GameObject scoreBoard;
	public GameObject mgrScore;
	int bestScore;

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	private void Update()
	{
		bestScore += mgrScore.GetComponent<manager>().score;
		scoreBoard.GetComponent<TextMeshProUGUI>().text = "Best Score: " + bestScore;
	}
}
