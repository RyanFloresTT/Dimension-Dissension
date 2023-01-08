using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{
    int killCount;
    public KillQuest(string name, string description, QuestType type, QuestDifficulty difficulty, GameObject reward)
        : base(name, description, type, difficulty, reward)
    {
        switch(difficulty) {
            case QuestDifficulty.Easy:
                killCount = Random.Range(5, 10);
                break;
            case QuestDifficulty.Medium:
                killCount = Random.Range(10, 15);
                break;
            case QuestDifficulty.Hard:
                killCount = Random.Range(15, 20);
                break;
            }
            
        Debug.Log(name + description + type + difficulty +  reward + killCount);
    }

}
