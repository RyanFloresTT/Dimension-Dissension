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
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        // Get the EnemyAI script component of the player game object and assign it to the player variable
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {        
        if (chasing) 
        {
            animator.SetBool("isMoving", true);
            // Calculate the distance between the enemy and the player
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (player.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            // If the distance between the enemy and the player is greater than the chaseDistance, move towards the player
            if (distance > attackRange) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            { 
                animator.SetBool("isMoving", false);
                // Check if enough time has passed since the last attack
                if (Time.time - lastAttackTime > attackDelay)
                {
                    // Attack the player
                    Attack();

                    // Update the time of the last attack
                    lastAttackTime = Time.time;
                }
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the enemy's collider entered the collider of the ground
        if (collision.gameObject.tag == "Ground")
        {
            // Set the "Idle" or "Move" trigger in the Animator component
            // depending on the current state of the enemy
            
            if (animator.GetBool("isMoving"))
            {
                animator.Play("Walking_Skeleton_Warrior");
            }
            else
            {
                animator.Play("Idle_Skeleton_Warrior");
            }
        }
    }

    // Attack is called to attack the player
    void Attack()
    {
        // Get the clip info for the current animation
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        // Set the wrap mode of the attack animation to Once
        clipInfo[0].clip.wrapMode = WrapMode.Once;
        
        // Play the attack animation
        animator.Play("Attack_Skeleton_Warrior");

        // Check if the player has a Health component
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Apply damage to the player
            playerHealth.TakeDamage(attackDamage);
        }
        // Reset the attack trigger after a short delay
        Invoke("ResetAttackTrigger", clipInfo[0].clip.length);
    }

    // Resets the attack trigger and sets the idle trigger
    void ResetAttackTrigger()
    {
        animator.ResetTrigger("Attack");
    }
}
