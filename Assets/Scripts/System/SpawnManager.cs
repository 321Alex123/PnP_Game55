using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyList;
    public float spawnRadius;

    private GameManager gameManager;
    private float spawnRate;
    private int enemiesSpawnCount = 1;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        var aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (!gameManager.gameOver && aliveEnemies.Length <= 0)
        {
            enemiesSpawnCount++;
            SpawnEnemyWave(enemiesSpawnCount);
        }
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(RandomEnemy(), GenerateSpawnPosition(), RandomEnemy().transform.rotation);
        }
    }

    private GameObject RandomEnemy()
    {
        var randomIndex = UnityEngine.Random.Range(0, enemyList.Length);
        var randomEnemy = enemyList[randomIndex];
        return randomEnemy;
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomCircle.x, 0, randomCircle.y) + transform.position;
        return spawnPosition;
    }
}
