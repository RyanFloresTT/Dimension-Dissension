using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackTime = 1.0f;
    public float attackDelay = 1.0f;
    public int combo = 0;
    public int maxCombo = 3;
    public float comboResetTime = 2.0f;
    public GameObject arrowPrefab;
    public float arrowVelocity;
    public float arrowInstantiationDelay = 0.5f;
    public Transform arrowSpawnPoint;
    private float comboTimer;
    private Animator animator;
    private bool attackStarted;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the combo timer
        comboTimer += Time.deltaTime;

        // If the combo timer exceeds the reset delay, reset the combo count
        if (comboTimer >= comboResetTime)
        {
            combo = 0;
        }
        // Check if the player is holding down the attack button
        if (Input.GetButton("Fire1"))
        {
            // Check if the attack delay has passed
            if (Time.time > attackTime)
            {
                // Perform an attack
                HandleCombo();

                // Set the attack time to the current time plus the attack delay
                attackTime = Time.time + attackDelay;
            }
        }
    }
    private void HandleCombo()
    {
        // Increment the combo count
        combo++;
        comboTimer = 0;

        // Make sure attack combo is below max, if it isn't, reset it and perform another attack.
        if (combo < maxCombo && !attackStarted)
        {
            attackStarted = true;
            // Do the attack
            StartCoroutine(Attack());
        }
        else if (combo == maxCombo && !attackStarted)
        {
            attackStarted = true;
            // Combo Attack
            StartCoroutine(Attack(2f));
        }
        else
        {
            attackStarted = true;
            // Reset combo and attack
            combo = 0;
            combo++;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack(float bonusSpeed = 1f)
    {
        
        // Get the clip info for the current animation
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        // Set the wrap mode of the attack animation to Once
        clipInfo[0].clip.wrapMode = WrapMode.Once;

        // Calculate the normalized time at which the arrow should be instantiated
        float arrowInstantiationTime = Time.time + arrowInstantiationDelay;

        // Set Player Animation to Attack
        animator.Play("Shot1_Skeleton_Archer", 0, arrowInstantiationTime);
            
        // Wait until the desired time to instantiate the arrow
        while (Time.time < arrowInstantiationTime)
        {
            // Wait for the next frame
            yield return null;
        }

        // Instantiate the arrow prefab at the arrow spawn point
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);

        // Flip the arrow horizontally based on the xScale of the player's transform
        arrow.transform.localScale = new Vector3(transform.localScale.x, arrow.transform.localScale.y, arrow.transform.localScale.z);

        // Get the Rigidbody2D component of the arrow
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        // Multiply the arrowVelocity by the xScale of the player's transform to control the direction of the arrow
        float arrowVelocityX = arrowVelocity * transform.localScale.x * bonusSpeed;

        // Apply a force to the arrow in the direction specified by the arrowVelocityX and arrowSpawnPoint.up vectors
        rb.AddForce(new Vector2(arrowVelocityX, 0), ForceMode2D.Impulse);

        // Destroy arrow after 2 seconds
        Destroy(arrow, 2f);

        // Reset the attack trigger after a short delay
        Invoke("ResetAttackTrigger", clipInfo[0].clip.length);

        // Wait 2 seconds before allowing the attack to be called again
        yield return new WaitForSeconds(2.0f);

        // Reset the attackStarted flag
        attackStarted = false;
    }

    // Resets the attack trigger and sets the idle trigger
    void ResetAttackTrigger()
    {
        animator.ResetTrigger("Shoot");
    }
}
