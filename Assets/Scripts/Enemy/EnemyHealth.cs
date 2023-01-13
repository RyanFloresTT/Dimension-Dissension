using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    public int startingHealth = 10;
    public int CurrentHealth { get; set; }
    private Material mat; 

    // Cache Variables
    private void Awake()
    {
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
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    // On Object Death
    public void OnDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
