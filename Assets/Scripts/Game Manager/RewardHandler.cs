using System.Collections;
using UnityEngine;

public class RewardHandler : MonoBehaviour
{
    // Singleton Setup
    public static RewardHandler instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private GameObject currentEquiped;

    private void Start()
    {
        currentEquiped = null;
    }

    public void HandleRewards(GameObject gameObject) { }    
}