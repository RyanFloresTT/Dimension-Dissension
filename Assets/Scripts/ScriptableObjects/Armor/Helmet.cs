using Interfaces.Armor;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Armor/Helmet", order = 1)]
public class Helmet : ArmorBase, IIsAHelmet
{
}