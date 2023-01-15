using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour, IHasHealth, IHasStats
{
    [SerializeField] private int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float AttackBonus { get; set; } 
    public float ArmorBonus { get; set; }
    public float CurrentHealth { get; set; }
    [SerializeField] private float _armorMultiplier;
    [SerializeField] public float _damageMultiplier;
    private Canvas _canvas;
    private TextMeshProUGUI _healthText;

    // Singleton Setup
    public static Player instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private void Awake()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        MaxHealth = startingHealth;
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
    public void TakeDamage(float damage)
    {
        float updatedDamage = damage - (ArmorBonus * _armorMultiplier);
        CurrentHealth -= updatedDamage;
        UpdateHealthUI();
    }
    // On Player Death
    public void OnDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
