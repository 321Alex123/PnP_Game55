using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPRocket : MonoBehaviour
{
    [SerializeField] private LayerMask shield;
    [SerializeField] private GameObject explosion;
    [SerializeField] float speed = 50;
    [SerializeField] int damage = 200;
    public GameObject target;

    private void Update()
    {
        if (target != null)
        {
            transform.position += Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == shield)
        {
            collision.gameObject.GetComponent<ForceFieldShield>().DeactivateShield();
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
