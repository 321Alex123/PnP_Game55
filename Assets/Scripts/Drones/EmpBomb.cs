using UnityEngine;

public class EmpBomb : MonoBehaviour
{
    public float speed = 10;
    Vector3 placeToSpawn;

    public ParticleSystem explosionEffectPrefab; // Предустановленный префаб системы частиц

    private ParticleSystem effectInstance; // Ссылка на созданный экземпляр системы частиц
    
    public void SetPosition(Vector3 place)
    {
        placeToSpawn = place;
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * placeToSpawn;
    }
    
    private void OnDestroy()
    {
        // Создаем копию системы частиц при уничтожении объекта
        effectInstance = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        effectInstance.Play(); // Воспроизводим систему частиц
    }

    private void OnDisable()
    {
        // Уничтожаем созданный экземпляр системы частиц при отключении объекта
        if (effectInstance != null)
        {
            Destroy(effectInstance.gameObject);
        }
    }
}