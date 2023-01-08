using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Direction of the arcane bolt
    public Vector3 direction;

    // Owner of the arcane bolt (the player that shot it)
    public GameObject owner;

    // Movement speed of the arcane bolt
    public float speed = 5.0f;

    // Damage dealt by the arcane bolt
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        // Move the arcane bolt in the specified direction
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the arcane bolt has collided with an enemy
        if (other.tag == "Enemy")
        {
            // Deal damage to the enemy
            other.GetComponent<EnemyHealth>().TakeDamage(damage);

            // Destroy the arcane bolt
            Destroy(gameObject);
        }
    }
}