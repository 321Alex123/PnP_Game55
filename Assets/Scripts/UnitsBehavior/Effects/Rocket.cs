using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] float speed = 50;
    [SerializeField] int damage = 200;
    public GameObject target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().RecieveDamage(damage);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}