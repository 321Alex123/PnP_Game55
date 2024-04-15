using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private GameObject target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode(collision.gameObject);
        }
    }

    private void Explode(GameObject unlucky)
    {
        unlucky.GetComponent<Health>().RecieveDamage(damage);
        health.Death();
    }
}
