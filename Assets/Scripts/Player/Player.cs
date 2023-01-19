using UnityEngine;

public class Player : MonoBehaviour, IHasHealth, IHasStats
{
    [SerializeField] private int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float AttackBonus { get; set; } 
    public float ArmorBonus { get; set; }
    public float CurrentHealth { get; set; }
    [SerializeField] private float _armorMultiplier;
    [SerializeField] public float _damageMultiplier;
    [SerializeField] private HealthBar _healthBar;

    // Singleton Setup
    public static Player instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        MaxHealth = startingHealth;
        CurrentHealth = MaxHealth;
        _healthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath(gameObject);
        }
    }

    // Deduct Health Points
    public void TakeDamage(float damage)
    {
        float updatedDamage = damage - ((ArmorBonus * _armorMultiplier) / 100); 
        CurrentHealth -= updatedDamage;
        Debug.Log("Player took :" + updatedDamage + " damage.");
        _healthBar.SetHelth(CurrentHealth);
    }
    
    // On Player Death
    public void OnDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
