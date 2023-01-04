using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float climbingSpeed = 3.5f;
    public float jumpForce = 10.0f;
    public int maxJumps = 2;

    private new Rigidbody2D rigidbody;
    private int jumpsRemaining;
    private Animator animator;
    private bool isClimbing;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        // Get a reference to the Animator component
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get input from the horizontal axis
        float input = Input.GetAxis("Horizontal");

        // If the player is moving, move, and set the animation to show
        if (input != 0)
        {
            // Set animator to show walking animation
            animator.SetBool("isMoving", true);
            // If going right, switch X scale to 1, else 'turn around' (Every now and then I get a little bit lonely...)
            if (input < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (input > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            // Set the player's velocity based on the input
            rigidbody.velocity = new Vector2(input * movementSpeed, rigidbody.velocity.y);
        }
        // If the player is not moving, set animation to stop showing
        if (input == 0)
        {
            animator.SetBool("isMoving", false);
        }
        // Check for jump input
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            // Apply a force to the player's rigidbody in the upward direction
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Decrement the number of jumps remaining
            jumpsRemaining--;
        }
        // Check if the player is climbing
        if (isClimbing)
        {
            // Get input from the vertical axis
            float vinput = Input.GetAxis("Vertical");

            // Set the player's velocity based on the input
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, vinput * climbingSpeed);

            // Set the player's gravity scale to 0 while climbing
            rigidbody.gravityScale = 0.0f;
        }
        else
        {
            // Set the player's gravity scale back to normal when not climbing
            rigidbody.gravityScale = 1.0f;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player's collider entered the collider of the ground
        if (collision.gameObject.tag == "Ground")
        {
            // Set the "Idle" or "Move" trigger in the Animator component
            // depending on the current state of the character
            
            if (animator.GetBool("isMoving"))
            {
                animator.Play("Walking_Skeleton_Archer");
            }
            else
            {
                animator.Play("Idle_Skeleton_Archer");
            }
            // Reset the number of jumps remaining
            jumpsRemaining = maxJumps;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player's collider left the collider of the ground
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetTrigger("Jump");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player's collider is no longer overlapping the trigger collider of a ladder or rope
        if (collision.gameObject.tag == "Climb")
        {
            // Disable climbing behavior
            isClimbing = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the player's collider is overlapping the trigger collider of a ladder or rope
        if (collision.gameObject.tag == "Climb")
        {
            // Enable climbing behavior
            isClimbing = true;
        }
    }
}
