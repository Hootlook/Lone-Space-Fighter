using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOOT;

namespace LOOT
{
	public class Rotater : MonoBehaviour 
	{
		public float speed;

		void Update ()
		{
			transform.Rotate (0, 0, Time.deltaTime*speed);
		}
	}
}