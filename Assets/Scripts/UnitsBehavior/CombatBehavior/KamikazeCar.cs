using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeCar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBaze"))
        {
            Explode(collision.gameObject);
        }
    }

    private void Explode(GameObject target)
    {
        target.GetComponent<Health>().RecieveDamage(damage);
        health.Death();
    }
}
