using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float attackRange = 1f;
    private GameObject _player;
    private SpriteRenderer _spriteRenderer;
    private EnemyHealth _enemyHealth;
    private bool _isAlive;

    // Cache variables
    private void Awake() 
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyHealth = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    private void Update()
    {
        _isAlive = _enemyHealth.IsCurrentlyAlive();

        if (!_isAlive) return;
        // Calculate the distance between the enemy and the player
        var playerPosition = _player.transform.position;
        var enemyPosition = transform.position;
        var distance = Vector2.Distance(enemyPosition, playerPosition);

        // Flip the enemy sprite to face the player's direction
        _spriteRenderer.flipX = playerPosition.x > enemyPosition.x;

        // If the distance between the enemy and the player is greater than the Attack Range, move towards the player
        if (distance > attackRange) 
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
        }
    }
}
