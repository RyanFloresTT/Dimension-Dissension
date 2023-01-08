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
            Destroy(gameObject);
        }
    }

    // Deduct Health points
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
