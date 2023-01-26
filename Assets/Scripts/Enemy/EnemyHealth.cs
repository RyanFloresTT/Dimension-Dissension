using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    private QuestManager _questManager;
    private Animator _animator;
    public int startingHealth = 10;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool IsAlive = true;
    [SerializeField] private float deathDelay = .5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip onHitClip;

    // Cache Variables
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _questManager = QuestManager.instance;
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
        IsAlive = false;
        _questManager.currentQuest.UpdateQuestProgress(1);
        _animator.SetTrigger("Die");
        Destroy(gameObject, deathDelay);
    }
}
