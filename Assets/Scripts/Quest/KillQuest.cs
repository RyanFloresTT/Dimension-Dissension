using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{
    public int killRequirement;
    EnemyType enemyType;
    public GameObject enemyPrefab;
    private string enemyTypeString;
    public EnemySpawner enemySpawner;
    public KillQuest(string questName, string description, QuestType type, QuestDifficulty difficulty, GameObject[] prefabs, int progress, GameObject reward)
        : base(questName, description, type, difficulty, prefabs, progress, reward)
    {
        InitializeQuest(this);
    }

    public override void InitializeQuest(Quest quest)
    {   
        // Load the enemy prefabs from the resources/enemies folder
        prefabs = Resources.LoadAll<GameObject>("Enemies");

        Debug.Log(prefabs);

        // Get a random amount of enemies to kill based on difficulty of the quest
        switch(difficulty) {
            case QuestDifficulty.Easy:
                killRequirement = Random.Range(5, 10);
                break;
            case QuestDifficulty.Medium:
                killRequirement = Random.Range(10, 15);
                break;
            case QuestDifficulty.Hard:
                killRequirement = Random.Range(15, 20);
                break;
        }

        // Choose a random enemy type the player has to kill
        // Get the array of enum names
        string[] names = EnemyType.GetNames(typeof(EnemyType));

        // Get the length of the enum
        int length = names.Length;

        // Choose a random index between 0 and length - 1
        int index = Random.Range(0, length);

        // Get the name of the element at the chosen index
        enemyTypeString = names[index];

        Debug.Log("Kill Quest Initialized. Quest Details: Kill " + killRequirement + " " + enemyTypeString +"s.");

        for (int i = 0; i < prefabs.Length; i++)
        {
            if (prefabs[i].name == enemyTypeString)
            {
                enemyPrefab = prefabs[i];
                Debug.Log(enemyPrefab);
            }
        }
        // Set the enemySpawner as the enemySpawner script from the game manager with the tag "GameController"
        GameObject gameManager = GameObject.FindGameObjectsWithTag("GameController")[0];
        enemySpawner = gameManager.GetComponent<EnemySpawner>();

        StartQuest();
    }

    public override void Update()
    {
        if (progress >= killRequirement)
        {
            this.isCompleted = true;
        }
    }

    public override void StartQuest()
    {
        enemySpawner.SpawnEnemies(killRequirement, enemyPrefab);
    }

}
