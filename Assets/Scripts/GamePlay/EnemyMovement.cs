using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = null;
    [SerializeField] private float drivingSpeed;
    [SerializeField] private float turningSpeed;
    private int nextWaypoint = 0;
    private Vector3 route;
    private Vector3 destination;
    private bool onRoute = false;

    private void Update()
    {
        if (onRoute)
        {
            if (route != null)
            {
                if (transform.rotation != Quaternion.LookRotation(route))
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(route), turningSpeed * Time.deltaTime);

                else if (transform.position != destination)
                    transform.position = Vector3.MoveTowards(transform.position, destination, drivingSpeed * Time.deltaTime);

                else if (waypoints.Count > nextWaypoint + 1)
                {
                    nextWaypoint++;
                    ChangeDirection();
                }
                else
                {
                    onRoute = false;
                }
            }
        }
    }

    public void ChangeDirection()
    {
        Vector3 direction = waypoints[nextWaypoint].position - transform.position;
        route = new Vector3(direction.x, 0, direction.z);
        destination = new Vector3(waypoints[nextWaypoint].position.x, waypoints[nextWaypoint].position.y, waypoints[nextWaypoint].position.z);
        onRoute = true;
    }
}
