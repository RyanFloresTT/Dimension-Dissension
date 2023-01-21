using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    private QuestManager questManager;
    public int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    // Cache Variables
    private void Awake()
    {
        questManager = QuestManager.instance;
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
            OnDeath();
        }
    }

    // Deduct Health points
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    // On Object Death
    public void OnDeath()
    {
        questManager.currentQuest.UpdateQuestProgress(1);
        Destroy(gameObject);
    }
}
