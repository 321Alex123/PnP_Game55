using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float speed = 20;
    [SerializeField] private int damage = 200;
    [SerializeField] private bool isEMP;
    private List<GameObject> targets = new List<GameObject>();
    public GameObject target;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        foreach (var target in targets)
        {
            target.GetComponent<Health>().RecieveDamage(damage);
        }
        Destroy(gameObject);
    }
}
