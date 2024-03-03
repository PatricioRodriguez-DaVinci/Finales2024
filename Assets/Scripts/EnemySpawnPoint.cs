using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject rangedEnemy;
    public GameObject meleeEnemy;
    public float spawnInterval = 3f;

    private void Start()
    {
        // Start spawning enemies immediately
        InvokeRepeating("SpawnRandomEnemy", 0f, spawnInterval);
    }

    private void SpawnRandomEnemy()
    {
        // Randomly choose which enemy to instantiate
        GameObject enemyPrefab = Random.Range(0, 3) == 0 ? rangedEnemy : meleeEnemy;

        // Instantiate the chosen enemy at the spawner's position
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
