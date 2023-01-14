using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ArmorToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _toolTip;
    private QuestManager _questManager;
    private PlayerArmorManager _armorManager;
    [SerializeField] private bool isRewardTooltip;
    [SerializeField] private bool isHelmetSlot;
    [SerializeField] private bool isChestSlot;
    [SerializeField] private bool isBootSlot;
    [SerializeField] private GameObject _itemSlot;
    private string _rewardName;
    private string _attackRating;
    private string _armorRating;

    private void Start()
    {
        _toolTip.SetActive(false);
        _questManager = QuestManager.instance;
        _armorManager = PlayerArmorManager.instance;
        _rewardName = _toolTip.transform.Find("RewardName").GetComponent<TMPro.TextMeshProUGUI>().text;
        _attackRating = _toolTip.transform.Find("AttackRating").GetComponent<TMPro.TextMeshProUGUI>().text;
        _armorRating = _toolTip.transform.Find("ArmorRating").GetComponent<TMPro.TextMeshProUGUI>().text;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isRewardTooltip)
        {
            _rewardName = _questManager.levelOneQuests[_questManager.questIndex].reward.armorName;
            _attackRating = "Attack: +" + _questManager.levelOneQuests[_questManager.questIndex].reward.attackRating;
            _armorRating = "Armor: +" + _questManager.levelOneQuests[_questManager.questIndex].reward.armorRating;
            _toolTip.SetActive(true);
        }
        else
        {

            if (isHelmetSlot)
            {
                if (_armorManager.armorList.Count == 1)
                {
                    ArmorBase armorSlot = _armorManager.armorList[0];
                    if (armorSlot != null)
                    {
                        _itemSlot.GetComponent<Image>().sprite = armorSlot.sprite;
                        _rewardName = armorSlot.armorName;
                        _attackRating = "Attack: +" + armorSlot.attackRating;
                        _armorRating = "Armor: +" + armorSlot.armorRating;
                        _toolTip.SetActive(true);
                    }
                }
            }
            else if (isChestSlot)
            {
                if (_armorManager.armorList.Count == 2)
                {
                    ArmorBase armorSlot = _armorManager.armorList[1];
                    if (armorSlot != null)
                    {
                        _itemSlot.GetComponent<Image>().sprite = armorSlot.sprite;
                        _rewardName = armorSlot.armorName;
                        _attackRating = "Attack: +" + armorSlot.attackRating;
                        _armorRating = "Armor: +" + armorSlot.armorRating;
                        _toolTip.SetActive(true);
                    }
                }
            }
            else if (isBootSlot)
            {
                if (_armorManager.armorList.Count == 3)
                {
                    ArmorBase armorSlot = _armorManager.armorList[2];
                    if (armorSlot != null)
                    {
                        _itemSlot.GetComponent<Image>().sprite = armorSlot.sprite;
                        _rewardName = armorSlot.armorName;
                        _attackRating = "Attack: +" + armorSlot.attackRating;
                        _armorRating = "Armor: +" + armorSlot.armorRating;
                        _toolTip.SetActive(true);
                    }
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _toolTip.SetActive(false);
    }
}
