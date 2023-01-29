using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;

    private void Start()
    {
        levelData.ResetLevel();
    }
}
