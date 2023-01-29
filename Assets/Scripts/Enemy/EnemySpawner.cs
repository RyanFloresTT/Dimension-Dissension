using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemySpawnPoints;
    
    public void SpawnEnemies(int maxEnemies, GameObject enemyPrefab )
    {
        for (var i = 0; i < maxEnemies ; i++)
        {
            var randomIndex = Random.Range(0, enemySpawnPoints.Length);
            var groundTile = enemySpawnPoints[randomIndex].transform.position;
            Instantiate(enemyPrefab, groundTile, Quaternion.identity);
        }
    }
}
