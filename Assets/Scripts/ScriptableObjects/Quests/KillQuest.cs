using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Quests", menuName = "Quests/KillQuest", order = 1)]
public class KillQuest : ScriptableObject
{
    // Set up ScriptableObject Variables
    [SerializeField] public string questName;
    [SerializeField] public string description;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int requirement;
    [SerializeField] public ArmorBase reward;
    private int _progress;

    // Class Variables
    private RewardHandler _rewardHandler;
    private EnemySpawner _enemySpawner;
    private GameObject _enemyPrefab;
    [SerializeField] private LevelData levelData;
    private Player _player;

    public void StartQuest()
    {
        _progress = 0;
        _rewardHandler = RewardHandler.Instance;
        _player = Player.Instance;
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _enemyPrefab = ChooseRandomEnemy(prefabs);
        SpawnQuestEntities(_enemyPrefab);
    }

    public void UpdateQuestProgress(int updatedProgress)
    {
        _progress += updatedProgress;

        if (_progress >= requirement)
            CompleteQuest();
    }

    private void CompleteQuest()    
    {
        _rewardHandler.HandleRewards(reward);
        levelData.NextLevel();
        HealPlayer();
    }

    private void HealPlayer()
    {
        if (_player.CurrentHealth >= _player.MaxHealth) return;
        _player.Heal(1);
    }

    private void SpawnQuestEntities(GameObject entity)
    {
        _enemySpawner.SpawnEnemies(requirement, entity);
    }

    private GameObject ChooseRandomEnemy(GameObject[] gameObjects)
    {
        // Get the length of the array
        var length = gameObjects.Length;

        // Choose a random index between 0 and length - 1
        var index = Random.Range(0, length);

        // Return the random indexed enemy choice
        return gameObjects[index];
    }
}
