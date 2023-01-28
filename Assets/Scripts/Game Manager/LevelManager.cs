using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Singleton Setup
    public static LevelManager instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private int _level = 1;

    public int GetLevel()
    {
        return _level;
    }

    public void NextLevel()
    {
        _level += 1;
    }
    
}
