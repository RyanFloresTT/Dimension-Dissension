using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The public instance of the EnemySpawner
    public static EnemySpawner instance;
    public int maxEnemies = 5;
    public float spawnDelay = 2.0f;
    [SerializeField] private GameObject _enemyPrefab;
    void Awake()
    {
        // Set the instance field to this instance of the EnemySpawner
        instance = this;
    }

    // Called once at the start of the script
    void Start()
    {
        //StartCoroutine(SpawnEnemies());
    }

    // Spawns Enemies
    public IEnumerator SpawnEnemies()
    {
        // Keep spawning enemies as long as the number of enemies in the scene is less than the maximum
        while (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            // Wait for the spawn delay
            yield return new WaitForSeconds(spawnDelay);

            // Find all the ground tiles in the scene
            GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Ground");

            // Choose a random ground tile
            int randomIndex = Random.Range(0, groundTiles.Length);
            GameObject groundTile = groundTiles[randomIndex];

            // Get the position of the ground tile
            Vector2 spawnPosition = groundTile.transform.position;

            // Offset the spawn position so the enemy prefab is spawned above the ground tile
            spawnPosition.y += 1.0f;

            // Instantiate the enemy at the spawn position
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
