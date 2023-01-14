using UnityEngine;

public class QuestBase : ScriptableObject
{
    // Set up ScriptableObject Variables
    [SerializeField] public string questName;
    [SerializeField] public string description;
    [SerializeField] private QuestDifficulty _difficulty;
    [SerializeField] private GameObject[] _prefabs;
    private int _progress;
    [SerializeField] private int _requirement;
    [SerializeField] public GameObject reward;
    private bool _isCompleted = false;

    // Class Variables
    private EnemySpawner _enemySpawner;
    private GameObject _enemyPrefab;

    public void StartQuest()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _enemyPrefab = ChooseRandomEnemy(_prefabs);
        SpawnQuestEntities(_enemyPrefab);
    }

    public void UpdateQuestProgress(int updatedProgress)
    {
        _progress += updatedProgress;

        if (_progress >= _requirement)
            CompleteQuest();
    }

    public void CompleteQuest()
    {
        _isCompleted = true;
        Debug.Log("Quest Completed");
    }

    public void SpawnQuestEntities(GameObject entity)
    {
        _enemySpawner.SpawnEnemies(_requirement, entity);
    }

    private GameObject ChooseRandomEnemy(GameObject[] gameObjects)
    {
        // Get the length of the array
        int length = gameObjects.Length;

        // Choose a random index between 0 and length - 1
        int index = Random.Range(0, length);

        // Return the random indexed enemy choice
        return gameObjects[index];
    }
}
