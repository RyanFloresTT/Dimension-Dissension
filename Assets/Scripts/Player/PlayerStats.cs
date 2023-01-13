using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour, IHasHealth
{
    [SerializeField] private int startingHealth = 10;
    public int CurrentHealth { get; set; }
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _healthText;

    // Start is called before the first frame update
    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        CurrentHealth = startingHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath(gameObject);
        }
    }
    
    // Updates The UI to show Current Health
    private void UpdateHealthUI()
    {
        _healthText.text = ("Health: " + CurrentHealth);
    }

    // Deduct Health Points
    public void TakeDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
        UpdateHealthUI();
    }
    // On Player Death
    public void OnDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
