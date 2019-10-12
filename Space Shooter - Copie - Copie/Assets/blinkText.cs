using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class blinkText : MonoBehaviour {

	TextMeshProUGUI text;
	public float time= 0;
	bool stade = false;
	private float startTime;
	public float duration = 5;
	float t;

	private void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
		startTime = Time.time;
	}

	private void Update()
	{
		t = (Time.time - startTime) / duration;
		text.alpha = time;

		if(stade == true)
		{
			down();
		}
		if(stade == false)
		{
			up();
		}


	}
	void up()
	{
		if (time < 100)
		{
			time = Mathf.SmoothStep(0, 100, t);
		}
		else stade = true;
	}
	void down()
	{
		if (time > 0)
		{
			time = Mathf.SmoothStep(100, 0, t);
		}
		else stade = false;
	}
}
