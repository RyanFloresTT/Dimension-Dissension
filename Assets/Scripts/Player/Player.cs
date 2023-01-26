using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
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
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip onHitClip;
    public bool IsAlive = true;
    private bool _deathZoomEnabled = false;
    private readonly string _shaderInnerOutline = "_InnerOutlineAlpha";
    private readonly string _shaderGlitch = "_GlitchAmount";
    private Camera _mainCamera;

    // Singleton Setup
    public static Player instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    private void Awake()
    {
        instance = this;
        CleanShaderProperties();
        _mainCamera = Camera.main;
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
        if (CurrentHealth <= 0 && IsAlive)
        {
            OnDeath();
            PlayDeathAnimation();
        }

        if (_deathZoomEnabled)  
        {
            _mainCamera.orthographicSize -= zoomSpeed * Time.deltaTime;
        }
    }

    // Deduct Health Points
    public void TakeDamage(float damage)
    {
        float updatedDamage = damage - ((ArmorBonus * _armorMultiplier) / 100); 
        CurrentHealth -= updatedDamage;
        audioSource.PlayOneShot(onHitClip);
        Debug.Log("Player took :" + updatedDamage + " damage.");
        _healthBar.SetHelth(CurrentHealth);
    }
    
    // On Player Death
    public void OnDeath()
    {
        IsAlive = false;
        audioSource.PlayOneShot(deathClip);
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
        playerMaterial.SetFloat(_shaderInnerOutline, 1f);
        playerMaterial.SetFloat(_shaderGlitch, 3f);
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void CleanShaderProperties()
    {
        playerMaterial.SetFloat(_shaderInnerOutline, 0f);
        playerMaterial.SetFloat(_shaderGlitch, 0f);
    }
}
