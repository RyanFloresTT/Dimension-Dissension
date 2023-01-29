namespace Interfaces
{
    public interface IIsATooltip
    {
        public ArmorBase GetArmorStats();
        public void SetTooltipText(ArmorBase reward);
        public void UpdateTooltipSprite();
    }
}