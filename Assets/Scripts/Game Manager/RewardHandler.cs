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
    private ArmorBase _armorPiece;

    private void Start()
    {
        _playerArmorManager = PlayerArmorManager.instance;
        _rewardMenu.SetActive(false);
    }

    public void HandleRewards(ArmorBase armor)
    {
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