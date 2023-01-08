using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;
using System;

public class QuestManager : MonoBehaviour
{
    public GameObject healthText;
    public GameObject buttons;
    public Quest[] quests;
    public Quest quest;

    // Start is called before the first frame update
    void Start()
    {   
        healthText.SetActive(false);
        Time.timeScale = 0;
        UpdateScrollText();
    }

    // Sets the current objective to the first set objective
    public void OnObjective1ButtonClicked()
    {
        quest = quests[0];
        StartQuest();
    }
    
    // Sets the current objective to the second set objective
    public void OnObjective2ButtonClicked()
    {
        quest = quests[1];
        StartQuest();
    }
    
    // Sets the current objective to the third set objective
    public void OnObjective3ButtonClicked()
    {
        quest = quests[2];
        StartQuest();
    }

    // Puts the game back into play and starts the quest
    public void StartQuest()
    {
        // Puts time back to normal and toggles active states of UI elements
        Time.timeScale = 1;
        buttons.SetActive(false);
        healthText.SetActive(true);
        QuestType questType = quest.type;

        Type questClassType = Type.GetType(questType.ToString() + "Quest");

        object[] parameters = new object[] { quest.name, quest.description, quest.type, quest.difficulty, quest.reward};
        Quest currentQuest = (Quest)Activator.CreateInstance(questClassType, parameters);
    }

    // Updates the Text of the 3 scrolls so that the player can see what options to choose
    public void UpdateScrollText()
    {
        // Find all objects with the tag "ScrollUI"
        GameObject[] scrollUIs = GameObject.FindGameObjectsWithTag("ScrollUI");

        for (int i = 0; i < quests.Length; i++)
        {
            // Get the name and description of the objective
            string objectiveName = quests[i].name;
            string objectiveDescription = quests[i].description;

            // Set the text of the name and description UI elements
            scrollUIs[i].transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = objectiveName;
            scrollUIs[i].transform.Find("Description").GetComponent<TMPro.TextMeshProUGUI>().text = objectiveDescription;
        }

    }
}
