using UnityEngine;


[System.Serializable]
public class Quest{
    public string questName; // the name of the objective
    public string description; // a brief description of the objective
    public QuestType type; // what type of quest it is
    public QuestDifficulty difficulty; // the difficulty of the quest
    public GameObject[] prefabs; // set the prefabs the quest will use
    public int progress = 0;
    public GameObject reward; // what reward the playe will receive after completion of the quest
    public bool isCompleted; // whether or not the objective has been completed

    // constructor for creating an Objective instance
    public Quest(string questName, string description, QuestType type, QuestDifficulty difficulty, GameObject[] prefabs, int progress, GameObject reward)
    {
        this.questName = questName;
        this.description = description;
        this.type = type;
        this.difficulty = difficulty;
        this.prefabs = prefabs;
        this.progress = progress;
        this.reward = reward;
        this.isCompleted = false;
    }

    public virtual void InitializeQuest(Quest quest)
    {
        Debug.Log(quest);
    }

    public virtual void Update(){}
    public virtual void StartQuest(){}
}
