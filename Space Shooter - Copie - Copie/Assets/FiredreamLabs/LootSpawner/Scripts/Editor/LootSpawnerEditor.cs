using LOOT;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace LOOT
{
    [CustomEditor(typeof(LootSpawner))]
    public class LootSpawnerEditor : Editor
    {
        string TextureName(GameObject obj)
		{
			return (obj!=null) ? obj.name.ToString() : "New Item";
		}

        string SetLabelText(bool checkBool)
		{
			return (checkBool==false) ? " ▶" : " ▼";
		}

		public override void OnInspectorGUI()
        {
            LootSpawner loot = (LootSpawner)target;

            EditorGUILayout.BeginVertical("Box");
			GUILayout.Label ("Loot Spawner", EditorStyles.boldLabel);

            loot.GizmoColour = EditorGUILayout.ColorField("Gizmo Colour", loot.GizmoColour);
            loot.spawnMethod = (LootSpawner.SpawnMethod)EditorGUILayout.EnumPopup("Spawn Method", loot.spawnMethod);

            if (loot.spawnMethod==LootSpawner.SpawnMethod.Seed||loot.spawnMethod==LootSpawner.SpawnMethod.Random)
            {
                GUILayout.Space(10);
			    GUILayout.Label ("Spawn Amount", EditorStyles.boldLabel);

                GUIContent swn = new GUIContent("Maximum Spawn", "Maximum amount of loot the script will spawn at any given time");
                GUIContent res = new GUIContent("Respawn Threshold", "Once the amount of spawned loot drops below this value it will respawn to the maximum amount");

                GUIContent min = new GUIContent("Minimum Respawn Time", "Respawn timer. Items will respawn after (Minimum) seconds");
                GUIContent max = new GUIContent("Maximum Respawn Time", "Respawn timer. Items will respawn between (Minimum) seconds and (Maximum) seconds");

                loot.maximumLoot = EditorGUILayout.IntField(swn, loot.maximumLoot);
                loot.respawnThreshold = EditorGUILayout.IntField(res, loot.respawnThreshold);

                GUILayout.Space(5);

                loot.respawnTimeMin = EditorGUILayout.FloatField(min, loot.respawnTimeMin);
                loot.respawnTimeMax = EditorGUILayout.FloatField(max, loot.respawnTimeMax);
            }
               
            GUILayout.Space(10);
			GUILayout.Label ("Loot Table", EditorStyles.boldLabel);
            
            foreach (LootTable item in loot.lootSpawn.ToList())
			{
                EditorGUILayout.BeginVertical("Box");

                if (GUILayout.Button(TextureName(item.lootPrefab) + SetLabelText(item.showInEditor), EditorStyles.boldLabel)) 
					item.showInEditor = !item.showInEditor;

                if (item.showInEditor)
                {
                    GUIContent unit = new GUIContent("Pre-spawn Units", "How many of this item is spawned at the start of the game; i.e. it's already spawned and reused when the spawner pulls it");

                    item.lootPrefab = (GameObject)EditorGUILayout.ObjectField("Item Prefab", item.lootPrefab, typeof(GameObject), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                    item.spawnChance = EditorGUILayout.IntSlider("Spawn Chance", item.spawnChance, 1, 100);

                    GUILayout.Space(10);
                    GUILayout.Label ("Spawn Rotation", EditorStyles.boldLabel);
                    item.initialRotation = EditorGUILayout.Vector3Field("Initial Rotation", item.initialRotation);

                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label ("Random Rotation (X,Y,Z)", GUILayout.Width(160));
                    GUILayout.FlexibleSpace();
                    item.randomRotationX = EditorGUILayout.Toggle("", item.randomRotationX, GUILayout.Width(40));
                    item.randomRotationY = EditorGUILayout.Toggle("", item.randomRotationY, GUILayout.Width(40));
                    item.randomRotationZ = EditorGUILayout.Toggle("", item.randomRotationZ, GUILayout.Width(40));
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();

                    GUILayout.Space(10);
                    GUILayout.Label ("Object Pool", EditorStyles.boldLabel);
                    item.poolUnits = EditorGUILayout.IntField(unit, item.poolUnits);

                    GUILayout.Space(10);
                    if (GUILayout.Button("Delete item")) 
                        loot.RemoveItem(item);
                }

                EditorGUILayout.EndVertical();
            }

			if (GUILayout.Button("Add new item")) 
                loot.AddNewItem();
            
            GUILayout.Space(2);
			EditorGUILayout.EndVertical();

            //Mark the scene as dirty; save all our values
            if(GUI.changed) {
				EditorUtility.SetDirty(loot);
				if (!EditorApplication.isPlaying) EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
			}
		}
	}
}