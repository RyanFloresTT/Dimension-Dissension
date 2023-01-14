using UnityEngine;

public class ArmorBase : ScriptableObject
{
    [SerializeField] public string armorName;
    [SerializeField] public float attackRating;
    [SerializeField] public float armorRating;
    [SerializeField] public Sprite sprite;
}