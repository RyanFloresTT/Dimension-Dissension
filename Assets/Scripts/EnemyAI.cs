using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 1f;
    public bool chasing = false;
    public bool wasHit = false;
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        // Get the EnemyAI script component of the player game object and assign it to the player variable
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {        
        if (chasing || wasHit) 
        {
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
            if (distance > 1) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
