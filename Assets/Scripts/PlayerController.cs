using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private SpriteRenderer spriteRenderer;
    private bool facingLeft = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get input for the horizontal and vertical axes
        float horizontalInput = 0;
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1;
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1;
        if (Input.GetKey(KeyCode.W)) verticalInput = 1;
        if (Input.GetKey(KeyCode.S)) verticalInput = -1;

        if (horizontalInput < 0 && !facingLeft)
        {
            spriteRenderer.flipX = true;
            facingLeft = true;
        }
        // Reset the flip if the player starts moving right
        else if (horizontalInput > 0 && facingLeft)
        {
            spriteRenderer.flipX = false;
            facingLeft = false;
        }

        // Calculate the direction the player should move in
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // Move the player in the calculated direction
        transform.position += direction * movementSpeed * Time.deltaTime;
    }
}
