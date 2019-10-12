using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LOOT;

namespace LOOT
{
	public class DemoController : MonoBehaviour 
	{
		public Button deleteButton;
		public Button reloadButton;
		public LootSpawner spawner;

		void Start()
		{
			deleteButton.onClick.AddListener (DeleteObjects);
			reloadButton.onClick.AddListener (ReloadScene);
		}

		void DeleteObjects()
		{
			spawner.DeleteSpawnedLoot();
		}

		void ReloadScene()
		{
			Application.LoadLevel ("Demo");
		}
	}
}