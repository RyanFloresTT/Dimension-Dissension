using System.Collections;
using UnityEngine;

public class KnockbackFeedback : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Material material;
    private Material _workingMaterial;
    [SerializeField] private float strength = 10f;
    [SerializeField] private float delay = 0.5f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _workingMaterial = new Material(material);
        gameObject.GetComponent<SpriteRenderer>().material = _workingMaterial;
    }

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        SetKnockbackVelocity(sender);
        SetShader();
        StartCoroutine(ResetToDefault());
    }

    private void SetShader()
    {
        _workingMaterial.SetFloat("_HitEffectBlend", 1f);
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
        _workingMaterial.SetFloat("_HitEffectBlend", 0f);
    }
}
