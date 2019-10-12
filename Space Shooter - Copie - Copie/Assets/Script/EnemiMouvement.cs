using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiMouvement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] List<Transform> waypoints;
	int waypointIndex;

	void Start()
	{
		// waypoints = WaveConfig.GetWaypoints();
		transform.position = waypoints[waypointIndex].position;
	}

	void Update()
	{
		Move();
	}

	void Move()
	{
		Debug.Log(waypointIndex);
		if (waypointIndex <= waypoints.Count - 1)
		{
			var targetPos = waypoints[waypointIndex].position;
			var speed = moveSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
			Debug.Log("Pos" + transform.position + targetPos);
			if (transform.position == targetPos)
			{
				waypointIndex++;
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}