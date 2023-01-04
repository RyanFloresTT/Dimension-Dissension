using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 10;
    public int currentHealth;
    public Canvas canvas;
    [SerializeField] private TextMeshProUGUI tmpText;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthUI();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthUI()
    {
        tmpText.text = ("Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth--;
        UpdateHealthUI();
        animator.SetTrigger("Hit");
    }
}
