using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 10;
    private int health;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = startingHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            animator.Play("Death_Skeleton_Warrior");
            Destroy(gameObject, 0.444f);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void OnDestroy()
    {
        // Restart the enemy spawn loop when the enemy is destroyed
        EnemySpawner.instance.StartCoroutine(EnemySpawner.instance.SpawnEnemies());
    }
}
