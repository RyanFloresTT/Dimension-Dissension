using UnityEngine;


[CreateAssetMenu(fileName = "Armor", menuName = "Armor/Helmet", order = 1)]
public class Helmet : ScriptableObject
{
    [SerializeField] private string armorName;
    [SerializeField] private float attackRating;
    [SerializeField] private float armorRating;
    [SerializeField] private Sprite sprite;
}