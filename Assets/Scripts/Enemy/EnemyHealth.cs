using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    private QuestManager _questManager;
    private Animator _animator;
    [SerializeField] private int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    private bool _isAlive = true;
    [SerializeField] private float deathDelay = .5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip onHitClip;

    // Cache Variables
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _questManager = QuestManager.Instance;
        audioSource = FindObjectOfType<AudioSource>();
    }

    // Config Variables
    private void Start()
    {
        CurrentHealth = startingHealth;
    }

    // Deduct Health points
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        audioSource.PlayOneShot(onHitClip);
        if (CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    // On Object Death
    public void OnDeath()
    {
        _isAlive = false;
        _questManager.GetCurrentQuest().UpdateQuestProgress(1);
        _animator.SetTrigger("Die");
        Destroy(gameObject, deathDelay);
    }

    public bool IsCurrentlyAlive()
    {
        return _isAlive;
    }
}
