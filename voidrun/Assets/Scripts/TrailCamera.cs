using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCamera : MonoBehaviour
{
    public Transform target;
    public float trailDistance = 3.5f;
    public float heightOffset = 3.0f;
    public float cameraDelay = 0.02f;


    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = target.position - target.forward * trailDistance;
        followPosition.y += heightOffset;
        transform.position += (followPosition - transform.position) * cameraDelay;

        transform.LookAt(target.transform);
        
    }
}
