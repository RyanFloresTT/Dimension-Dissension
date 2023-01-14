using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject _healthText;
    [SerializeField] private GameObject _questGroup;
    [SerializeField] private GameObject _leftQuestButton;
    [SerializeField] private GameObject _rightQuestButton;
    [SerializeField] private GameObject _questBoard;
    private int questIndex = 0;
    private KillQuest[] levelOneQuests;
    public KillQuest currentQuest;

    // Singleton Setup
    public static QuestManager   instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }


    // Start is called before the first frame update
    void Start()
    {   
        currentQuest = null;
        _healthText.SetActive(false);
        Time.timeScale = 0;
        PopulateQuestList();
        UpdateScrollText();

        _leftQuestButton.SetActive(false);
    }

    private void PopulateQuestList()
    {
        levelOneQuests = Resources.LoadAll<KillQuest>("LevelOneQuests");
    }

    // Sets the current objective to the first set objective
    public void OnObjective1ButtonClicked()
    {
        currentQuest = levelOneQuests[questIndex];
        StartQuest();
    }
    
    // Sets the current objective to the second set objective
    public void OnObjective2ButtonClicked()
    {
        currentQuest = levelOneQuests[questIndex];
        StartQuest();
    }
    
    // Sets the current objective to the third set objective
    public void OnObjective3ButtonClicked()
    {
        currentQuest = levelOneQuests[questIndex];
        StartQuest();
    }

    public void OnNextQuestLeftButtonClicked()
    {
        questIndex--;
        if (questIndex == 0)
            _leftQuestButton.SetActive(false);

        if (questIndex == levelOneQuests.Length - 2)
            _rightQuestButton.SetActive(true);

        UpdateScrollText();
    }    

    public void OnNextQuestRightButtonClicked()
    {
        questIndex++;
        if (questIndex == levelOneQuests.Length - 1)
            _rightQuestButton.SetActive(false);

        if (questIndex == 1)
            _leftQuestButton.SetActive(true);

        UpdateScrollText();

    }

    // Puts the game back into play and starts the quest
    public void StartQuest()
    {
        // Puts time back to normal and toggles active states of UI elements
        Time.timeScale = 1;
        _healthText.SetActive(true);
        _questGroup.SetActive(false);
        currentQuest.StartQuest();

    }

    // Updates the Text of the 3 scrolls so that the player can see what options to choose
    public void UpdateScrollText()
    {
        string questName = levelOneQuests[questIndex].questName;
        string questDescription = levelOneQuests[questIndex].description;
        GameObject reward = levelOneQuests[questIndex].reward;

        _questBoard.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = questName;
        _questBoard.transform.Find("Description").GetComponent<TMPro.TextMeshProUGUI>().text = questDescription;
        _questBoard.transform.Find("RewardImg").GetComponent<Image>().sprite = reward.GetComponent<SpriteRenderer>().sprite;
    }
}
