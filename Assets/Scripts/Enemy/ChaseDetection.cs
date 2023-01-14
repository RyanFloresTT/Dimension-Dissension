using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDetection : MonoBehaviour
{
    [SerializeField] private GameObject _playerGameObject;
    private EnemyMovement _enemyScript;
    void Awake()
    {
        var parentGameObject = this.transform.parent.gameObject;
        _enemyScript = parentGameObject.GetComponent<EnemyMovement>();
        _playerGameObject = Player.instance.gameObject;
    }

    // OnTriggerEnter2D is called when the enemy's collider enters a trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the enemy is entering the player's trigger collider
        if (collider.gameObject == _playerGameObject)
        {
            _enemyScript.chasing = true;
        }
    }
}
