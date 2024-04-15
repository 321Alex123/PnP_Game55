using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float speed = 50;
    [SerializeField] private int damage;
    [SerializeField] private int liveDuration = 5;
    public bool isEnemy;

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(liveDuration);
        Destroy(gameObject);
    }

    private void Awake()
    {
        StartCoroutine(Destruction());
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isEnemy)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Health>().RecieveDamage(damage);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().RecieveDamage(damage);
            }
        }
        
        Destroy(gameObject);
    }
}
