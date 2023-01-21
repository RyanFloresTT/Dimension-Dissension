using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackFeedback : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Material _material;
    [SerializeField] private float strength = 10f;
    [SerializeField] private float delay = 0.5f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _material = GetComponent<Material>();
    }

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        SetKnockbackVelocity(sender);
        StartCoroutine(ResetToDefault());
        
    }

    private void SetKnockbackVelocity(GameObject sender)
    {
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        _rigidbody2D.AddForce(direction * strength, ForceMode2D.Impulse);
    }

    private IEnumerator ResetToDefault()
    {
        yield return new WaitForSeconds(delay);
        _rigidbody2D.velocity = Vector3.zero;
    }
}
