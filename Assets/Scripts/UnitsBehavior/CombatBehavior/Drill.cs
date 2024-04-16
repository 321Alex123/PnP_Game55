using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] private LayerMask playerBaze;
    [SerializeField] private int damage = 50;
    [SerializeField] private int damagePeriod = 1;
    private GameObject target;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == playerBaze)
        {
            target = collision.gameObject;
            StartCoroutine(DealDamage());
        }
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            audioSource.Play();

            if (target != null)
            {
                Health targetHealth = target.GetComponent<Health>();
                if (targetHealth != null)
                {
                    targetHealth.RecieveDamage(damage);
                }
            }

            yield return new WaitForSeconds(damagePeriod);
        }
    }
}
