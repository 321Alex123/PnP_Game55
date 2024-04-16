using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    [SerializeField] private int damagePeriod = 1;
    private GameObject target;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            target = collision.gameObject;
            StartCoroutine(DealDamage());
        }
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            target.GetComponent<Health>().RecieveDamage(damage);
            yield return new WaitForSeconds(damagePeriod);
        }
    }
}
