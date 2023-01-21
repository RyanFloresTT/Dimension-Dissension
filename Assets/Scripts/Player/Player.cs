using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private Material playerMaterial;
    [SerializeField] private int zoomDelay = 2;
    [SerializeField] private float zoomSpeed = .1f;
    public bool IsAlive = true;
    private bool _deathZoomEnabled = false;

    // Singleton Setup
    public static Player instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        MaxHealth = startingHealth;
        CurrentHealth = MaxHealth;
        _healthBar.SetMaxHealth(MaxHealth);
        CleanShaderProperties();
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath();
        }

        if (_deathZoomEnabled)  
        {
            Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;
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
    public void OnDeath()
    {
        IsAlive = false;
        PlayDeathAnimation();
        StartCoroutine(TriggerDeathZoom());
        
    }

    private IEnumerator TriggerDeathZoom()
    {
        _deathZoomEnabled = true;
        yield return new WaitForSeconds(zoomDelay);
        LoadGameOver();
    }

    private void PlayDeathAnimation()
    {
        playerMaterial.SetFloat("_InnerOutlineAlpha", 1f);
        playerMaterial.SetFloat("_GlitchAmount", 3f);
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void CleanShaderProperties()
    {
        playerMaterial.SetFloat("_InnerOutlineAlpha", 0f);
        playerMaterial.SetFloat("_GlitchAmount", 0f);
    }
}
