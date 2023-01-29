using TMPro;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackRatingText;
    [SerializeField] private TextMeshProUGUI armorRatingText;
    private Player _player;

    private void Start()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        attackRatingText.text = "" + _player.AttackBonus;
        armorRatingText.text = "" + _player.ArmorBonus;
    }
}
