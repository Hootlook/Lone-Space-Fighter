using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public GameObject Target;
    [Range(0, 1)]
    public float followingSpeed;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Target.transform.position, followingSpeed);
    }
}
