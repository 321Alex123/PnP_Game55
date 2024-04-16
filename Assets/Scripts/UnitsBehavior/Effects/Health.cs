using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int rewardMoney;
    [SerializeField] private int refundMoney;

    [SerializeField] private GameObject explosionObject;
    [SerializeField] public int health;
    private bool isEnemy;
    [SerializeField] private bool isBase;
    private EnemySpawn enemySpawn;
    private Recources playerBaseWallet;

    private void Awake()
    {
        playerBaseWallet = FindAnyObjectByType<Recources>();
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
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
        if (gameObject.CompareTag("Enemy"))
        {
            playerBaseWallet.AddScrap(rewardMoney);
        }

        if (gameObject.CompareTag("Player"))
        {
            playerBaseWallet.AddScrap(refundMoney);
        }

        if (SelectByClick.selectedDrones.Contains(gameObject))
        {
            SelectByClick.selectedDrones.Remove(gameObject);
        }
        if (!isEnemy && !isBase)
        {
            Destroy(gameObject.GetComponent<SelectionIndication>().selectionButton.gameObject);
        }
        if (isEnemy)
        {
            enemySpawn.currentWave.Remove(gameObject);
        }
        if(isBase)
        {
            GetComponent<Base>().BaseDestroyed();
        }
        Instantiate(explosionObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
