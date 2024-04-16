using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMovement : MonoBehaviour
{
    private FinalPosition finalPosition;

    public List<Transform> waypoints = null;
    [SerializeField] private float drivingSpeed;
    [SerializeField] private float turningSpeed;
    private int nextWaypoint = 0;
    private Vector3 route;
    private Vector3 destination;
    private bool onRoute = false;
    private bool onFinal = false;

    [SerializeField] private bool isDrill;
    [SerializeField] private bool isAPC;
    [SerializeField] private bool isKamikaze;

    private void Awake()
    {
        finalPosition = FindAnyObjectByType<FinalPosition>();
    }

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
                    if (!onFinal) onRoute = false;
                    if (!onFinal) SelectFinalPosition();
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

    private void SelectFinalPosition()
    {
        if (isDrill)
        {
            MoveToFinalPosition(finalPosition.SelectPosition("Drill"));
        }
        else if (isAPC)
        {
            MoveToFinalPosition(finalPosition.SelectPosition("APC"));
        }
        else if (isKamikaze)
        {
            MoveToFinalPosition(finalPosition.SelectPosition("Kamikaze"));
        }
    }

    private void MoveToFinalPosition(Transform finalPosition)
    {
        Vector3 direction = finalPosition.position - transform.position;
        route = new Vector3(direction.x, 0, direction.z);
        destination = new Vector3(finalPosition.position.x, finalPosition.position.y, finalPosition.position.z);
        onRoute = true;
        onFinal = true;
    }
}
