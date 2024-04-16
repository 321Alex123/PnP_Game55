using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] private int damage = 50;
    [SerializeField] private int damagePeriod = 1;
    private GameObject target;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
            target.GetComponent<Health>().RecieveDamage(damage);
            yield return new WaitForSeconds(damagePeriod);
        }
    }
}
