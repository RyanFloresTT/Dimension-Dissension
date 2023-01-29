using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IHasHealth, IHasStats
{
    [SerializeField] private int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float AttackBonus { get; set; } 
    public float ArmorBonus { get; set; }
    public float CurrentHealth { get; set; }
    [SerializeField] private float armorMultiplier;
    [SerializeField] public float damageMultiplier;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Material playerMaterial;
    [SerializeField] private int zoomDelay = 2;
    [SerializeField] private float zoomSpeed = .1f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip onHitClip;
    public bool isAlive = true;
    private bool _deathZoomEnabled = false;
    private const string ShaderInnerOutline = "_InnerOutlineAlpha";
    private const string ShaderGlitch = "_GlitchAmount";
    private Camera _mainCamera;

    // Singleton Setup
    public static Player Instance { get; private set; }
    private void OnEnable() { Instance = this; }
    private void OnDisable() { Instance = null; }

    private void Awake()
    {
        Instance = this;
        CleanShaderProperties();
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    private void Start()
    {
        MaxHealth = startingHealth;
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if (CurrentHealth <= 0 && isAlive)
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
        var updatedDamage = damage - ((ArmorBonus * armorMultiplier) / 100); 
        CurrentHealth -= updatedDamage;
        audioSource.PlayOneShot(onHitClip);
        Debug.Log("Player took :" + updatedDamage + " damage.");
        healthBar.SetHealth(CurrentHealth);
    }

    public void Heal(float health)
    {
        CurrentHealth += health;
        healthBar.SetHealth(CurrentHealth);
    }
    
    // On Player Death
    public void OnDeath()
    {
        isAlive = false;
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
        playerMaterial.SetFloat(ShaderInnerOutline, 1f);
        playerMaterial.SetFloat(ShaderGlitch, 3f);
    }

    private static void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void CleanShaderProperties()
    {
        playerMaterial.SetFloat(ShaderInnerOutline, 0f);
        playerMaterial.SetFloat(ShaderGlitch, 0f);
    }
}
