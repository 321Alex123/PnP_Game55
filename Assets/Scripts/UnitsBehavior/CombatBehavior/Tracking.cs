using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 250;
    public GameObject target = null;
    private Quaternion lookAtRotation;


    private void Update()
    {
        if (target != null)
        {
            lookAtRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            if (transform.rotation != lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
