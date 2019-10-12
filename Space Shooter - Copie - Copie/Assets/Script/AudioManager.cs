﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	private void Awake()
	{
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}

	}

	private void Update()
	{
		if (Input.GetKeyDown("n"))
		{
			//sounds[0].source.Play();
		}

	}


}
