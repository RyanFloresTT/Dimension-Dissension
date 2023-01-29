using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject questGroup;
    [SerializeField] private GameObject leftQuestButton;
    [SerializeField] private GameObject rightQuestButton;
    [SerializeField] private GameObject questBoard;
    private int _questIndex;
    private List<KillQuest> _quests = new();
    private KillQuest _currentQuest;
    public static QuestManager Instance { get; private set; }
    private void OnEnable() { Instance = this; }
    private void OnDisable() { Instance = null; }
    private void Start()
    {
        InitializeQuest();
    }

    public void InitializeQuest()
    {
        questGroup.SetActive(true);
        _questIndex = 0;
        _currentQuest = null;
        healthBar.SetActive(false);
        Time.timeScale = 0;
        PopulateQuestList();
        UpdateScrollText();

        leftQuestButton.SetActive(false);
        rightQuestButton.SetActive(true);
    }

    private void PopulateQuestList()
    {
        _quests?.Clear();
        GetRandomQuests();
        
    }

    private void GetRandomQuests()
    {
        
        _quests.Add(GetEasyQuest());
        _quests.Add(GetMediumQuest());
        _quests.Add(GetHardQuest());
        
    }

    private KillQuest GetEasyQuest()
    {
        var questHolder = Resources.LoadAll<KillQuest>("Quests/Easy");
        var randomIndex = Random.Range(0, questHolder.Length-1);
        return questHolder[randomIndex];
    }

    private KillQuest GetMediumQuest()
    {
        var questHolder = Resources.LoadAll<KillQuest>("Quests/Medium");
        var randomIndex = Random.Range(0, questHolder.Length-1);
        return questHolder[randomIndex];
    }

    private KillQuest GetHardQuest()
    {
        var questHolder = Resources.LoadAll<KillQuest>("Quests/Hard");
        var randomIndex = Random.Range(0, questHolder.Length-1);
        return questHolder[randomIndex];
    }

    public void OnQuestAccept()
    {
        _currentQuest = _quests[_questIndex];
        StartQuest();
    }

    public void OnNextQuestLeftButtonClicked()
    {
        _questIndex--;
        Debug.Log(_questIndex);
        if (_questIndex == 0)
            leftQuestButton.SetActive(false);

        if (_questIndex == _quests.Count - 2)
            rightQuestButton.SetActive(true);

        UpdateScrollText();
    }    

    public void OnNextQuestRightButtonClicked()
    {
        _questIndex++;
        Debug.Log(_questIndex);
        if (_questIndex == _quests.Count - 1)
            rightQuestButton.SetActive(false);

        if (_questIndex == 1)
            leftQuestButton.SetActive(true);

        UpdateScrollText();

    }

    private void StartQuest()
    {
        Time.timeScale = 1;
        healthBar.SetActive(true);
        questGroup.SetActive(false);
        _currentQuest.StartQuest();

    }

    private void UpdateScrollText()
    {
        var questName = _quests[_questIndex].questName;
        var questDescription = _quests[_questIndex].description;
        var reward = _quests[_questIndex].reward;
        
        Debug.Log(_quests[_questIndex]);

        questBoard.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = questName;
        questBoard.transform.Find("Description").GetComponent<TMPro.TextMeshProUGUI>().text = questDescription;
        questBoard.transform.Find("RewardImg").GetComponent<Image>().sprite = reward.sprite;
    }

    public int GetQuestIndex()
    {
        return _questIndex;
    }

    public List<KillQuest> GetQuestList()
    {
        return _quests;
    }

    public KillQuest GetCurrentQuest()
    {
        return _currentQuest;
    }
}
