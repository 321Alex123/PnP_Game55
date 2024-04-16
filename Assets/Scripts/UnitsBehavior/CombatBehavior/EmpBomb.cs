using UnityEngine;
using UnityEngine.UIElements;

public class EmpBomb : MonoBehaviour
{
    public float speed = 10;
    Vector3 direction = new Vector3();

    public ParticleSystem explosionEffectPrefab;

    private ParticleSystem effectInstance; 

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
        }
    }
}