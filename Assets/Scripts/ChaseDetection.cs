using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDetection : MonoBehaviour
{
    EnemyAI script;
    void Start()
    {
        var parentGameObject = this.transform.parent.gameObject;
        script = parentGameObject.GetComponent<EnemyAI>();
    }

    // OnTriggerEnter2D is called when the enemy's collider enters a trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the enemy is entering the player's trigger collider
        if (collider.gameObject.tag == "Player")
        {
            script.chasing = true;
        }
    }
}
