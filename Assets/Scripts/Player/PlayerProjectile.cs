using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IIsProjectile
{
    public Player player;
    public Vector3 direction;
    public GameObject owner;
    public float speed;
    public float Damage { get; set; }
    [SerializeField] private float damageMultiplier;

    private void Start()
    {
        player = Player.Instance;
        damageMultiplier = player.damageMultiplier;
        Damage = 1;
        Damage += player.AttackBonus * damageMultiplier;
    }

    private void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<IHasHealth>();
        var playerComponent = other.GetComponent<Player>();
        if (health == null || playerComponent != null) return;
        other.GetComponent<IHasHealth>().TakeDamage(Damage);
        other.GetComponent<KnockbackFeedback>().PlayFeedback(gameObject);
        Destroy(gameObject);
    }
}