using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public TimeController myTimeController;
    public GameObject rangedEnemy;
    public GameObject meleeEnemy;
    public float spawnInterval = 3f;
    public float radius;

    private void Start()
    {
        // Start spawning enemies immediately
        InvokeRepeating("SpawnRandomEnemy", 0f, spawnInterval);
    }

    private void SpawnRandomEnemy()
    {
        if (!Physics.CheckSphere(transform.position, radius) && myTimeController.timeRemaining > 0)
        {
            // Randomly choose which enemy to instantiate
            GameObject enemyPrefab = Random.Range(0, 3) == 0 ? rangedEnemy : meleeEnemy;

            // Instantiate the chosen enemy at the spawner's position
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
