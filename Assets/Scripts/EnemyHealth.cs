using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 10;
    private int health;
    private Material mat; 
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject, 0.444f);
        }
    }

    public void TakeDamage(int damage)
    {
        mat.SetFloat("_HitEffectBlend", 0.135f);
        health -= damage;
    }

    void OnDestroy()
    {
        // Restart the enemy spawn loop when the enemy is destroyed
        EnemySpawner.instance.StartCoroutine(EnemySpawner.instance.SpawnEnemies());
    }
}
