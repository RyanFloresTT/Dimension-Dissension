using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1;
    private Player _player;
    private KnockbackFeedback _playerKnockback;

    private void Start()
    {
        _player = Player.instance;
        _playerKnockback = _player.gameObject.GetComponent<KnockbackFeedback>();
    }

    // On Trigger Enter, Make the Player take damage.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player isPlayer = collision.GetComponent<Player>();

        if (isPlayer)
        {
            _player.TakeDamage(attackDamage);
            _playerKnockback.PlayFeedback(gameObject);
        }
    }
}
