using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
public float speed = 1f;
public float attackRange = 1f;
public int attackDamage = 1;
public float attackDelay = 2f;
private float lastAttackTime = 0f;
public bool chasing = false;
private GameObject player;
private new Rigidbody2D rigidbody;
private Animator animator;

private void Awake() 
{
    // Get the EnemyAI script component of the player game object and assign it to the player variable
    player = GameObject.FindGameObjectWithTag("Player");
}

void Start()
{
    rigidbody = GetComponent<Rigidbody2D>(); 
}

// Update is called once per frame
void Update()
{        
    if (chasing) 
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // If the distance between the enemy and the player is greater than the chaseDistance, move towards the player
        if (distance > attackRange) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (distance < attackRange)
        {
            // Check if enough time has passed since the last attack
            if (Time.time - lastAttackTime > attackDelay) {
                Debug.Log("attack");
                // Attack the player
                Attack();
                animator.SetTrigger("Attack");

                // Update the time of the last attack
                lastAttackTime = Time.time;
            }
        }
    }
}

// Attack is called to attack the player
void Attack()
{
    // Check if the player has a Health component
    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
    if (playerHealth != null)
    {
        // Apply damage to the player
        playerHealth.TakeDamage(attackDamage);
    }
}
}
