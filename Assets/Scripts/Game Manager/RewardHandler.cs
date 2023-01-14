using System.Collections;
using UnityEngine;

public class RewardHandler : MonoBehaviour
{
    // Singleton Setup
    public static RewardHandler instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    // Variables
    [SerializeField] private GameObject _rewardMenu;
    private PlayerArmorManager _playerArmorManager;
    private QuestManager _questManager;
    private ArmorBase _armorPiece;

    private void Start()
    {
        _questManager = QuestManager.instance;
        _playerArmorManager = PlayerArmorManager.instance;
        _rewardMenu.SetActive(false);
    }

    public void HandleRewards(ArmorBase armor)
    {
        _rewardMenu.transform.Find("RewardName").GetComponent<TMPro.TextMeshProUGUI>().text = _questManager.levelOneQuests[_questManager.questIndex].reward.armorName;
        _rewardMenu.transform.Find("AttackRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Attack: +" + _questManager.levelOneQuests[_questManager.questIndex].reward.attackRating;
        _rewardMenu.transform.Find("ArmorRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Armor: +" + _questManager.levelOneQuests[_questManager.questIndex].reward.armorRating;
        _rewardMenu.SetActive(true);
        _armorPiece = armor;
    }

    public void AcceptReward()
    {
        _playerArmorManager.AddArmorPiece(_armorPiece);
        _rewardMenu.SetActive(false);
    }
    public void DeclineReward()
    {
        _rewardMenu.SetActive(false);
    }
}