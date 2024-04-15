using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private float speed = 1;
    private int nextWaypoint = 0;

    private void Update()
    {
        if (transform.position != waypoints[nextWaypoint].position)
            transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint].position, speed * Time.deltaTime);
        else if (waypoints.Count > nextWaypoint + 1)
            nextWaypoint++;
        else
            nextWaypoint = 0;
    }
}
