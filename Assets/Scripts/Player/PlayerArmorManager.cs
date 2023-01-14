using UnityEngine;

public class PlayerArmorManager : MonoBehaviour
{
    [SerializeField] private Helmet[] armorList;
    private Player player;

    private void Start()
    {
        player = Player.instance;
    }

    public void OnEquip()
    {

    }
}