using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSave : MonoBehaviour
{
    // Singleton Setup
    public static CanvasSave instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
