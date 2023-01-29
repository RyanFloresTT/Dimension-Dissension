using System;
using System.Linq;
using Armor;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Tooltips
{
    public class HelmetSheetTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IIsATooltip
    {
        [SerializeField] private GameObject toolTip;
        [SerializeField] private Image characterSheetArmorImage;
        [SerializeField] private PlayerArmorManager armorManager;

        private void Start()
        {
            toolTip.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            UpdateTooltipSprite();
            var armor = GetArmorStats();
            if (armor == null) return;
            toolTip.SetActive(true);
        }

        public ArmorBase GetArmorStats()
        {
            var armorList = armorManager.GetArmorList();
            return armorList?.FirstOrDefault(armor => armor.GetArmorType() == ArmorType.Helm);
        }

        public void SetTooltipText(ArmorBase armor)
        {
            toolTip.transform.Find("RewardName").GetComponent<TMPro.TextMeshProUGUI>().text = armor.armorName;
            toolTip.transform.Find("AttackRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Attack: +" + armor.attackRating;
            toolTip.transform.Find("ArmorRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Armor: +" + armor.armorRating;
        }

        public void UpdateTooltipSprite()
        {
            var headPiece = GetArmorStats();
            if (headPiece == null) return;
            characterSheetArmorImage.sprite = headPiece.sprite;
            SetTooltipText(headPiece);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            toolTip.SetActive(false);
        }
    }
}
