using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionObject;
    [SerializeField] public int health;
    private bool isEnemy;

    private void Awake()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            isEnemy = true;
        }
    }

    public void RecieveDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if (SelectByClick.selectedDrones.Contains(gameObject))
        {
            SelectByClick.selectedDrones.Remove(gameObject);
        }
        if (!isEnemy)
        {
            Destroy(gameObject.GetComponent<SelectionIndication>().selectionButton.gameObject);
        }
        Instantiate(explosionObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
