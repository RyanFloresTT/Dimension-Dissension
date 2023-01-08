using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The public instance of the EnemySpawner
    public static EnemySpawner instance;
    public int maxEnemies = 5;
    [SerializeField] private GameObject _enemyPrefab;

    // Called once at the start of the script
    void Start()
    {
        SpawnEnemies();
    }

    // Spawns Enemies
    public void SpawnEnemies()
    {
        // Keep spawning enemies as long as the number of enemies in the scene is less than the maximum
        while (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {

            // Find all the ground tiles in the scene
            GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("EnemySpawn");

            // Choose a random ground tile
            int randomIndex = Random.Range(0, groundTiles.Length);
            GameObject groundTile = groundTiles[randomIndex];

            // Get the position of the ground tile
            Vector3 spawnPosition = new Vector3(groundTile.transform.position.x, groundTile.transform.position.y, 0);

            // Instantiate the enemy at the spawn position
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
