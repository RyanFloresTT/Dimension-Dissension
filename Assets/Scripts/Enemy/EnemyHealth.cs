using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    private QuestManager questManager;
    public int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    private Material mat; 

    // Cache Variables
    private void Awake()
    {
        questManager = QuestManager.instance;
        mat = GetComponent<Renderer>().material;
    }

    // Config Variables
    private void Start()
    {
        CurrentHealth = startingHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath(gameObject);
        }
    }

    // Deduct Health points
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    // On Object Death
    public void OnDeath(GameObject gameObject)
    {
        questManager.currentQuest.UpdateQuestProgress(1);
        Destroy(gameObject);
    }
}
