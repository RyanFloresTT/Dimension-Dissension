using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerArmorManager : MonoBehaviour
{
    // Singleton Setup
    public static PlayerArmorManager instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    [SerializeField] public List<ArmorBase> armorList = new List<ArmorBase>();

    private Player _player;
    private void Start()
    {
        // populate the armorList from the serialized array
        _player = Player.instance;

        if (armorList.Count != 0)
        {  
            // If there is armor in the array, then make sure to add those to the player's stats
            AddArmorStats();
        } else
        {
            // set default armor and attack bonus to 0 if there is no currently equiped armor
            _player.AttackBonus = 0;
            _player.ArmorBonus = 0;
        }
    }

    private void AddArmorStats()
    {
        // Set Stats to zero before adding all armor stats
        _player.AttackBonus = 0;
        _player.ArmorBonus = 0;
        foreach (ArmorBase armor in armorList)
        {
            _player.AttackBonus += armor.attackRating;
            _player.ArmorBonus += armor.armorRating;
        }
    }
    
    public void AddArmorPiece(ArmorBase armor)
    {
        armorList.Add(armor);
        AddArmorStats();
    }
}