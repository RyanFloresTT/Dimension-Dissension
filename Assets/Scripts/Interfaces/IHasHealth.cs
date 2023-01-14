
using UnityEngine;

interface IHasHealth
{
    float CurrentHealth { get; set; }
    float MaxHealth { get; set; }
    void TakeDamage(float damage);
    void OnDeath(GameObject gameObject);
}
