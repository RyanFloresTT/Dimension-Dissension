using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private GameObject playerGameObject;


    // On Trigger Enter, Make the Player take damage.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerGameObject)
        { 
            playerGameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }
}
