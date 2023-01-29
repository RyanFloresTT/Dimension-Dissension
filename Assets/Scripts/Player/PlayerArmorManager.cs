using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerArmorManager : MonoBehaviour
{
    public static PlayerArmorManager Instance { get; private set; }
    private void OnEnable() { Instance = this; }
    private void OnDisable() { Instance = null; }

    [SerializeField] private List<ArmorBase> armorList = new();

    private Player _player;
    private void Start()
    {
        _player = Player.Instance;
        
        armorList.Clear();
        _player.AttackBonus = 0;
        _player.ArmorBonus = 0;
    }

    private void AddArmorStats()
    {
        _player.AttackBonus = 0;
        _player.ArmorBonus = 0;
        foreach (var armor in armorList)
        {
            _player.AttackBonus += armor.attackRating;
            _player.ArmorBonus += armor.armorRating;
        }
    }
    
    public void AddArmorPiece(ArmorBase armor)
    {
        armorList.Add(armor);
        AddArmorStats();
        Debug.Log("Added " + armor+".");
    }

    public void SwitchArmorPiece(ArmorBase newArmor, ArmorBase currentArmor)
    {
        var armorIndex = armorList.FindIndex(d=>d == currentArmor);
        Debug.Log(armorIndex);
        armorList.RemoveAt(armorIndex);
        Debug.Log("Switched " + currentArmor + "with " + newArmor+ ".");
    }

    public List<ArmorBase> GetArmorList()
    {
        return armorList;
    }
}