using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOOT;

namespace LOOT
{
	public class LootObject : MonoBehaviour 
	{
		public bool canPickupObject = true;

		[HideInInspector]
		public LootSpawner spawner;

		//This is an example of "picking up" an object
		void OnMouseDown()
		{
			PickupObject();
		}

		public void PickupObject()
		{
			if (canPickupObject)
				spawner.DestroyObject(this.gameObject);
		}
	}
}