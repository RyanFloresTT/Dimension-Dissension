using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackRatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackRatingText;
    [SerializeField] private TextMeshProUGUI _armorRatingText;
    private Player _player;

    private void Start()
    {
        _player = Player.instance;
    }

    private void Update()
    {
        _attackRatingText.text = "" + _player.AttackBonus;
        _armorRatingText.text = "" + _player.ArmorBonus;
    }
}
