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
    private GameManager _gameManager;
    [SerializeField] private float levelLoadDelay = 3f;
    [SerializeField] private Animator transitionAnimator;

    private void Start()
    {
        _questManager = QuestManager.instance;
        _playerArmorManager = PlayerArmorManager.instance;
        _rewardMenu.SetActive(false);
        _gameManager = GameManager.instance;
    }

    public void HandleRewards(ArmorBase armor)
    {
        _armorPiece = armor;
        _rewardMenu.transform.Find("RewardName").GetComponent<TMPro.TextMeshProUGUI>().text = _armorPiece.armorName;
        _rewardMenu.transform.Find("AttackRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Attack: +" + _armorPiece.attackRating;
        _rewardMenu.transform.Find("ArmorRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Armor: +" + _armorPiece.armorRating;
        _rewardMenu.SetActive(true);
    }

    public void AcceptReward()
    {
        _playerArmorManager.AddArmorPiece(_armorPiece);
        _rewardMenu.SetActive(false);
        transitionAnimator.SetTrigger("Start");
        StartCoroutine(_gameManager.LoadNextLevel(levelLoadDelay));
    }
    public void DeclineReward()
    {
        _rewardMenu.SetActive(false);
        StartCoroutine(_gameManager.LoadNextLevel(levelLoadDelay));
    }
}