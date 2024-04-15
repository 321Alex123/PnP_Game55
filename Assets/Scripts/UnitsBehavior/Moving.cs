using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float flightSpeed;
    [SerializeField] private float turningSpeed;
    [SerializeField] private float flightHeight;

    private Vector3 route;
    private bool onRoute = false;

    private void Update()
    {
        if (onRoute)
        {
            if (transform.rotation != Quaternion.LookRotation(route - transform.position) && transform.position != route)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(route - transform.position), turningSpeed * Time.deltaTime);
            else if (transform.position != route)
                transform.position = Vector3.MoveTowards(transform.position, route, flightSpeed * Time.deltaTime);
            else
                onRoute = false;
        }
    }

    public void MoveToPosition(Vector3 position)
    {
        route = new Vector3(position.x, flightHeight, position.z);
        onRoute = true;
    }
}
