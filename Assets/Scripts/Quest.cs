using UnityEngine;

[System.Serializable]
public class Quest {
    public string name; // the name of the objective
    public string description; // a brief description of the objective
    public QuestType type; // what type of quest it is
    public QuestDifficulty difficulty; // the difficulty of the quest
    public GameObject reward; // what reward the playe will receive after completion of the quest
    public bool isCompleted; // whether or not the objective has been completed


    // constructor for creating an Objective instance
    public Quest(string name, string description, QuestType type, QuestDifficulty difficulty, GameObject reward)
    {
        this.name = name;
        this.description = description;
        this.type = type;
        this.difficulty = difficulty;
        this.reward = reward;
        this.isCompleted = false;
    }
}
