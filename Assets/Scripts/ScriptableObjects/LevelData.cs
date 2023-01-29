using  UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int level;

        public int GetLevel()
        {
            return level;
        }

        public void NextLevel()
        {
            level++;
        }

        public void ResetLevel()
        {
            level = 0;
        }
    }
}