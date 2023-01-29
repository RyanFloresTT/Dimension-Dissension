using ScriptableObjects;
using TMPro;
using UnityEngine;

public class GameOverLevel : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Start()
    {
        levelText.text = (levelData.GetLevel().ToString());
    }
    
}
