using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverLevel : MonoBehaviour
{
    private LevelManager _levelManager;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Start()
    {
        _levelManager = LevelManager.instance;
        levelText.text = (_levelManager.GetLevel().ToString());
    }
    
}
