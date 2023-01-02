using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Animator animator;
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Hit");
            Destroy(gameObject);
            Debug.Log("Hit");
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
