using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LOOT
{
	public class LootSpawner : MonoBehaviour 
	{
		public SpawnMethod spawnMethod;
        public Color GizmoColour = new Color(1, 0, 0, 0.5f);

		[Header("Spawner")]
        public int maximumLoot;
        public int respawnThreshold;
		public float respawnTimeMin;
		public float respawnTimeMax;

		public List<LootTable> lootSpawn = new List<LootTable>();
        public List<GameObject> spawnedLoot = new List<GameObject>();

		bool isSpawning;

		public int randomSeed = 32523;
		GameObject spawnedLootTransform;

		public enum SpawnMethod { Seed, Random, SingleItem }
		public Dictionary<string, Queue<GameObject>> poolDictionary;

		void Start()
		{
			if (lootSpawn.Count-1 < 0)
                return;

			CreatePool();
			AssignSeed();
			LootTransform();
			CalculateLoot();
		}

		void Update()
		{
			ManageLoot();
		}

		void AssignSeed()
		{
			if (spawnMethod==SpawnMethod.Seed)
				Random.InitState(randomSeed); //Set our seed
		}

		void ManageLoot()
		{
			if (lootSpawn.Count-1 < 0)
                return;

			for (int i=0; i<spawnedLoot.Count; i++)
                if (!spawnedLoot[i]) //If we can't find the gameobject
                    spawnedLoot.Remove(spawnedLoot[i]); //Remove it from the list

            if (spawnedLoot.Count <= respawnThreshold && !isSpawning) //Respawn our loot once we pass the threshold
                StartCoroutine(SpawnMoreLoot(Random.Range(respawnTimeMin, respawnTimeMax)));
		}

		void LootTransform()
		{
			spawnedLootTransform = GameObject.Find("Spawned Loot"); //Search for and assign our Spawned Loot transform

            if (!spawnedLootTransform)
			{
                spawnedLootTransform = new GameObject("Spawned Loot"); //Create one if we can't find it
				spawnedLootTransform.transform.SetParent(this.transform);
			}
		}

		public int AmountToSpawn()
		{
			return (spawnMethod==SpawnMethod.SingleItem) ? 1 : maximumLoot;
		}

		public Vector3 PositionToSpawn()
		{
			return (spawnMethod==SpawnMethod.SingleItem) ? Vector3.zero : new Vector3(Random.Range(-transform.localScale.z/2, transform.localScale.x/2), Random.Range(-transform.localScale.y/2, transform.localScale.y/2),  Random.Range(-transform.localScale.z/2, transform.localScale.z/2));
		}

		public void CalculateLoot()
		{
            if (lootSpawn.Count-1 < 0)
                return; //we don't have any loot prefabs

            if (!spawnedLootTransform)
                return; //we can't find our spawned loot transform

			while (spawnedLoot.Count < AmountToSpawn())
            {
				//Start spawning our loot
                //Generate a random position within our bounds
				//If we're using Single Item spawning, we spawn at Vector3.zero
				Vector3 spawnPosition = PositionToSpawn();

                for (int i=0; i<lootSpawn.Count; i++)
                {
                    if (Random.Range(0, 100) <= lootSpawn[i].spawnChance)
                    {
						//Initial rotation
						Vector3 spawnRotation = lootSpawn[i].initialRotation;

						//Set our random rotations (if enabled)
						if (lootSpawn[i].randomRotationX) spawnRotation.x = Random.Range(0,360);
						if (lootSpawn[i].randomRotationY) spawnRotation.y = Random.Range(0,360);
						if (lootSpawn[i].randomRotationZ) spawnRotation.z = Random.Range(0,360);

						GameObject loot = SpawnFromPool(lootSpawn[i].lootPrefab.name, transform.position + spawnPosition, Quaternion.Euler(spawnRotation));
                                   loot.transform.SetParent(spawnedLootTransform.transform);

                        spawnedLoot.Add(loot);

                        if (loot.GetComponent<LootObject>())
                            loot.GetComponent<LootObject>().spawner = this;

                        break;
                    }
                }
			}
		}

		public void DestroyObject(GameObject loot)
		{
			for (int i=0; i<spawnedLoot.Count; i++)
            {
                if (spawnedLoot[i]==loot)
                {
                    SendToPool(spawnedLoot[i]);
                    spawnedLoot.Remove(spawnedLoot[i]);
                }
            }
		}

		public void DeleteSpawnedLoot()
        {
            int itemID = 0;

            while (spawnedLoot.Count>0)
            {
                itemID = spawnedLoot.Count-1;

                SendToPool(spawnedLoot[itemID]);
                spawnedLoot.Remove(spawnedLoot[itemID]);

                itemID--;
            }
        }

		IEnumerator SpawnMoreLoot(float seconds)
        {
            isSpawning = true;
            yield return new WaitForSeconds(seconds);
            CalculateLoot();
            isSpawning = false;
        }

		void CreatePool()
		{
			LootTransform();
			poolDictionary = new Dictionary<string, Queue<GameObject>>();

			foreach(LootTable pool in lootSpawn)
			{
				Queue<GameObject> objectPool = new Queue<GameObject>();

				for (int i=0; i<pool.poolUnits; i++)
				{
					GameObject obj = Instantiate(pool.lootPrefab);
							   obj.transform.SetParent(spawnedLootTransform.transform);
							   obj.SetActive(false);
					
					objectPool.Enqueue(obj);
				}

				poolDictionary.Add(pool.lootPrefab.name, objectPool);
			}
		}

		public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
		{
			if (!poolDictionary.ContainsKey(tag)) 
			{
				Debug.Log("Pool with tag "+tag+" does not exist");
				return null;
			}

			GameObject objectToSpawn = poolDictionary[tag].Dequeue();
			objectToSpawn.SetActive(true);
			objectToSpawn.transform.position = pos;
			objectToSpawn.transform.rotation = rot;

			poolDictionary[tag].Enqueue(objectToSpawn);

			return objectToSpawn;
		}

		public void SendToPool(GameObject obj)
		{
			obj.SetActive(false);
		}

		void OnDrawGizmos()
        {
            Gizmos.color = GizmoColour;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }

		public void AddNewItem()
		{
			LootTable newItem = new LootTable();
			lootSpawn.Add(newItem);
		}

		public void RemoveItem(LootTable item)
		{
			lootSpawn.Remove(item);
		}
	}

	[System.Serializable]
    public class LootTable
    {
		public int poolUnits;
        public GameObject lootPrefab;
        [Range(0, 100)] public int spawnChance;

		public Vector3 initialRotation;
		public bool randomRotationX;
		public bool randomRotationY;
		public bool randomRotationZ;

		public bool showInEditor = true;
    }
}