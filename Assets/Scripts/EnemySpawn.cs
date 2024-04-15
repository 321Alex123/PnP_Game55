using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnA;
    [SerializeField] private Transform spawnB;
    [SerializeField] private Transform spawnC;

    [SerializeField] private List<GameObject> enemyPrefabsA1 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsB1 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsC1 = new List<GameObject>();

    [SerializeField] private List<Transform> enemyRouteA = new List<Transform>();
    [SerializeField] private List<Transform> enemyRouteB = new List<Transform>();
    [SerializeField] private List<Transform> enemyRouteC = new List<Transform>();

    [SerializeField] private int spawnDelay = 2;

    IEnumerator SpawnInQueue(List<GameObject> enemyPrefabs, Transform spawn, List<Transform> enemyRoute)
    {
        foreach (var enemyPrefab in enemyPrefabs)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawn.position, spawn.rotation);
            enemy.GetComponent<EnemyMovement>().waypoints = enemyRoute;
            enemy.GetComponent<EnemyMovement>().ChangeDirection();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Start()
    {
        Debug.Log("Start");
        SpawnEnemies(enemyPrefabsA1, enemyPrefabsB1, enemyPrefabsC1);
    }

    private void SpawnEnemies(List<GameObject> enemyPrefabsA, List<GameObject> enemyPrefabsB, List<GameObject> enemyPrefabsC)
    {
        StartCoroutine(SpawnInQueue(enemyPrefabsA, spawnA, enemyRouteA));
        StartCoroutine(SpawnInQueue(enemyPrefabsB, spawnB, enemyRouteB));
        StartCoroutine(SpawnInQueue(enemyPrefabsC, spawnC, enemyRouteC));
    }
}
