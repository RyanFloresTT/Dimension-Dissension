using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1;
    private Player _player;
    private KnockbackFeedback _playerKnockback;
    private EnemyHealth _enemyHealth;
    private bool _isAlive;

    private void Start()
    {
        _player = Player.instance;
        _playerKnockback = _player.gameObject.GetComponent<KnockbackFeedback>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        _isAlive = _enemyHealth.IsAlive;
    }

    // On Trigger Enter, Make the Player take damage.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player isPlayer = collision.GetComponent<Player>();

        if (isPlayer && _isAlive)
        {
            _player.TakeDamage(attackDamage);
            _playerKnockback.PlayFeedback(gameObject);
        }
    }
}
