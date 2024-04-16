using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI spawnAText;
    [SerializeField] private TextMeshProUGUI spawnBText;
    [SerializeField] private TextMeshProUGUI spawnCText;

    [SerializeField] private WinAndLoss winAndLoss;

    [SerializeField] private Transform spawnA;
    [SerializeField] private Transform spawnB;
    [SerializeField] private Transform spawnC;

    [SerializeField] private List<GameObject> enemyPrefabsA1 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsB1 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsC1 = new List<GameObject>();

    [SerializeField] private List<GameObject> enemyPrefabsA2 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsB2 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsC2 = new List<GameObject>();

    [SerializeField] private List<GameObject> enemyPrefabsA3 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsB3 = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyPrefabsC3 = new List<GameObject>();

    [SerializeField] private List<Transform> enemyRouteA = new List<Transform>();
    [SerializeField] private List<Transform> enemyRouteB = new List<Transform>();
    [SerializeField] private List<Transform> enemyRouteC = new List<Transform>();

    [SerializeField] private int spawnDelay = 2;
    private int waveNumber = 0;
    public List<GameObject> currentWave = new List<GameObject>();
    public bool gameStarted = false;
    private bool spawning = false;

    IEnumerator SpawnEnemies(List<GameObject> enemyPrefabs, Transform spawn, List<Transform> enemyRoute)
    {
        foreach (var enemyPrefab in enemyPrefabs)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawn.position, spawn.rotation);
            enemy.GetComponent<EnemyMovement>().waypoints = enemyRoute;
            enemy.GetComponent<EnemyMovement>().ChangeDirection();
            currentWave.Add(enemy);
            yield return new WaitForSeconds(spawnDelay);
        }
        spawning = false;
    }

    private void Update()
    {
        if (gameStarted)
        {
            if (currentWave.Count == 0 && !spawning)
            {
                waveNumber++;
                StartNextWave();
            }
        }
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void StartNextWave()
    {
        spawning = true;

        if (waveNumber == 1)
        {
            spawnAText.text = enemyPrefabsA1.Count.ToString();
            spawnBText.text = enemyPrefabsB1.Count.ToString();
            spawnCText.text = enemyPrefabsC1.Count.ToString();
            StartCoroutine(SpawnEnemies(enemyPrefabsA1, spawnA, enemyRouteA));
            StartCoroutine(SpawnEnemies(enemyPrefabsB1, spawnB, enemyRouteB));
            StartCoroutine(SpawnEnemies(enemyPrefabsC1, spawnC, enemyRouteC));
        }
        if (waveNumber == 2)
        {
            spawnAText.text = enemyPrefabsA2.Count.ToString();
            spawnBText.text = enemyPrefabsB2.Count.ToString();
            spawnCText.text = enemyPrefabsC2.Count.ToString();
            StartCoroutine(SpawnEnemies(enemyPrefabsA2, spawnA, enemyRouteA));
            StartCoroutine(SpawnEnemies(enemyPrefabsB2, spawnB, enemyRouteB));
            StartCoroutine(SpawnEnemies(enemyPrefabsC2, spawnC, enemyRouteC));
        }
        if (waveNumber == 3)
        {
            spawnAText.text = enemyPrefabsA3.Count.ToString();
            spawnBText.text = enemyPrefabsB3.Count.ToString();
            spawnCText.text = enemyPrefabsC3.Count.ToString();
            StartCoroutine(SpawnEnemies(enemyPrefabsA3, spawnA, enemyRouteA));
            StartCoroutine(SpawnEnemies(enemyPrefabsB3, spawnB, enemyRouteB));
            StartCoroutine(SpawnEnemies(enemyPrefabsC3, spawnC, enemyRouteC));
        }
        if (waveNumber == 4)
        {
            winAndLoss.WinOrLoss(true);
        }
    }
}
