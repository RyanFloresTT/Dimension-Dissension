
using UnityEngine;

interface IHasHealth
{
    int CurrentHealth { get; set; }
    void TakeDamage(int damage);
    void OnDeath(GameObject gameObject);
}
