using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    public bool chasing = false;
    [SerializeField] private float _attackRange = 1f;
    private GameObject _player;
    private SpriteRenderer _spriteRenderer;

    // Cache variables
    private void Awake() 
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {        
        if (chasing) 
        {
            // Calculate the distance between the enemy and the player
            float distance = Vector2.Distance(transform.position, _player.transform.position);

            // Flip the enemy sprite to face the player's direction
            if (_player.transform.position.x > transform.position.x)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }

            // If the distance between the enemy and the player is greater than the Attack Range, move towards the player
            if (distance > _attackRange) 
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            }
        }
    }
}
