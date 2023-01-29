using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Armor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RewardHandler : MonoBehaviour
{
    // Singleton Setup
    public static RewardHandler Instance { get; private set; }
    private void OnEnable() { Instance = this; }
    private void OnDisable() { Instance = null; }

    // Variables
    [SerializeField] private GameObject rewardMenu;
    private PlayerArmorManager _playerArmorManager;
    private ArmorBase _armorPiece;
    private GameManager _gameManager;
    [SerializeField] private float levelLoadDelay = 3f;
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private GameObject[] tooltips;

    private void Start()
    {
        _playerArmorManager = PlayerArmorManager.Instance;
        rewardMenu.SetActive(false);
        _gameManager = GameManager.Instance;
    }

    public void HandleRewards(ArmorBase armor)
    {
        _armorPiece = armor;
        rewardMenu.transform.Find("RewardName").GetComponent<TMPro.TextMeshProUGUI>().text = _armorPiece.armorName;
        rewardMenu.transform.Find("AttackRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Attack: +" + _armorPiece.attackRating;
        rewardMenu.transform.Find("ArmorRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Armor: +" + _armorPiece.armorRating;
        rewardMenu.SetActive(true);
    }

    public void AcceptReward()
    {
        CheckCurrentArmor();
        rewardMenu.SetActive(false);
        UpdateCharacterSheetToolTips();
        transitionAnimator.SetTrigger("Start");
        StartCoroutine(_gameManager.LoadNextLevel(levelLoadDelay));
    }

    private void UpdateCharacterSheetToolTips()
    {
        foreach (var tooltip in tooltips)
        {
            if (tooltip.GetComponent<IIsATooltip>() != null)
            {
                tooltip.GetComponent<IIsATooltip>().UpdateTooltipSprite();
            }
        }
    }

    private void CheckCurrentArmor()
    {
        var armorList = _playerArmorManager.GetArmorList();
        if (!armorList.Any())
        {
            Debug.Log("Nothing in list. Adding First Armor.");
            _playerArmorManager.AddArmorPiece(_armorPiece);
        }
        else
        {
            foreach (var armor in armorList.ToList())
            {
                if (_armorPiece.GetArmorType() == armor.GetArmorType())
                {
                    Debug.Log("Armor type matched, replacing...");
                    _playerArmorManager.SwitchArmorPiece(_armorPiece, armor);
                    break;
                }
            }
            Debug.Log("No Armor match found, adding...");
            _playerArmorManager.AddArmorPiece(_armorPiece);
        }
    }

    public void DeclineReward()
    {
        rewardMenu.SetActive(false);
        StartCoroutine(_gameManager.LoadNextLevel(levelLoadDelay));
    }
}