using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The public instance of the EnemySpawner
    public static EnemySpawner instance;
    [SerializeField] private GameObject[] enemySpawnPoints;

    private void Awake()
    {
        instance = this;
    }

    // Spawns Enemies
    public void SpawnEnemies(int maxEnemies, GameObject enemyPrefab )
    {
        // Keep spawning enemies as long as the number of enemies in the scene is less than the maximum
        for (int i = 0; i < maxEnemies ; i++)
        {
            // Choose a random ground tile
            int randomIndex = Random.Range(0, enemySpawnPoints.Length);
            GameObject groundTile = enemySpawnPoints[randomIndex];

            // Get the position of the ground tile
            Vector3 spawnPosition = new Vector3(groundTile.transform.position.x, groundTile.transform.position.y, 0);

            // Instantiate the enemy at the spawn position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
