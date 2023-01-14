using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private GameObject playerGameObject;
    private Player _player;

    private void Start()
    {
        _player = Player.instance;
    }

    // On Trigger Enter, Make the Player take damage.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player isPlayer = collision.GetComponent<Player>();

        if (isPlayer)
        { 
            _player.TakeDamage(attackDamage);
        }
    }
}
