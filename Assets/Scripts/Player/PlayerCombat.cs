using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackTime = 1.0f;
    public float attackDelay = 1.0f;
    public float projectileSpeed = 5.0f;
    public GameObject projPrefab;
    private Player _player;

    private void Start()
    {
        _player = Player.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!_player.IsAlive) return;
        // Check if the player is holding down the attack button
        if (Input.GetButton("Fire1"))
        {
            // Check if the attack delay has passed
            if (Time.time > attackTime)
            {
                // Get mouse position
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;

                // Calculate the direction to the mouse
                Vector3 direction = (mousePosition - transform.position).normalized;
                // Perform an attack, sending the direction var to instantiate
                Attack(direction);

                // Set the attack time to the current time plus the attack delay
                attackTime = Time.time + attackDelay;
            }
        }
    }
    // Shoot the projectile at the cursor location, rotating the sprite to point towards it as well.
    void Attack(Vector3 direction)
    {
        // Create a projectile game object
        GameObject projectile = Instantiate(projPrefab, transform.position, Quaternion.identity);

        // Calculate the angle between the projectile's direction and the cursor click
        float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);

        // Rotate the projectile to the correct angle
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Set the direction of the arcane bolt
        projectile.GetComponent<PlayerProjectile>().direction = direction;

        // Set the speed of the projectile
        projectile.GetComponent<PlayerProjectile>().speed = projectileSpeed;

        // Set the player as the owner of the arcane bolt
        projectile.GetComponent<PlayerProjectile>().owner = gameObject;

        // Destroy Projectile after 2 seconds
        Destroy(projectile, 2);
    }
}
