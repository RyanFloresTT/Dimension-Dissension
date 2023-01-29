using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Tooltips
{
    public class RewardArmorToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IIsATooltip
    {
        [SerializeField] private GameObject toolTip;
        private QuestManager _questManager;

        private void Start()
        {
            toolTip.SetActive(false);
            _questManager = QuestManager.Instance;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            var reward = GetArmorStats();
            SetTooltipText(reward);
            toolTip.SetActive(true);
        }

        public ArmorBase GetArmorStats()
        {
            var questList = _questManager.GetQuestList();
            var questIndex = _questManager.GetQuestIndex();
            return questList[questIndex].reward;
        }

        public void SetTooltipText(ArmorBase reward)
        {
            toolTip.transform.Find("RewardName").GetComponent<TMPro.TextMeshProUGUI>().text = reward.armorName;
            toolTip.transform.Find("AttackRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Attack: +" + reward.attackRating;
            toolTip.transform.Find("ArmorRating").GetComponent<TMPro.TextMeshProUGUI>().text = "Armor: +" + reward.armorRating;
        }

        public void UpdateTooltipSprite()
        {}

        public void OnPointerExit(PointerEventData eventData)
        {
            toolTip.SetActive(false);
        }
    }
}
