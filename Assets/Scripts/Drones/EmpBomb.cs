using UnityEngine;
using UnityEngine.UIElements;

public class EmpBomb : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float speed = 10;

    public ParticleSystem explosionEffectPrefab;

    private ParticleSystem effectInstance; 

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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
        Instantiate(explosion, transform.position, transform.rotation);
        unlucky.GetComponent<Health>().
    }
}