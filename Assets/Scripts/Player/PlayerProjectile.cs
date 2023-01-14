using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IIsProjectile
{
    public Player player;
    // Direction of the arcane bolt
    public Vector3 direction;
    // Owner of the arcane bolt (the player that shot it)
    public GameObject owner;
    // Movement speed of the arcane bolt
    public float speed;
    // Damage dealt by the arcane bolt
    public float Damage { get; set; }
    [SerializeField] private float _damageMultiplier;

    private void Start()
    {
        player = Player.instance;
        _damageMultiplier = player._damageMultiplier;
        Damage = 1;
        Damage += player.AttackBonus * _damageMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the arcane bolt in the specified direction
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IHasHealth health = other.GetComponent<IHasHealth>();
        Player player = other.GetComponent<Player>();
        
        // Check if the projectile hits something with health that is NOT the player.
        if (health != null && player == null)
        {   
            // tell the enemy they were hit, so they can chase the player
            other.GetComponent<EnemyMovement>().chasing = true;

            // Deal damage to the enemy
            other.GetComponent<IHasHealth>().TakeDamage(Damage);

            // Destroy the arcane bolts
            Destroy(gameObject);
        }
    }
}