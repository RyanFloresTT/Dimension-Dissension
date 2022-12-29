using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public int maxJumps = 2;

    private Rigidbody2D rigidbody;
    private int jumpsRemaining;
    private Animator animator;

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
        // Check for jump input
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            // Apply a force to the player's rigidbody in the upward direction
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Decrement the number of jumps remaining
            jumpsRemaining--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player's collider entered the trigger collider of the ground
        if (collision.gameObject.tag == "Ground")
        {
            // Reset the number of jumps remaining
            jumpsRemaining = maxJumps;
        }
    }
}
