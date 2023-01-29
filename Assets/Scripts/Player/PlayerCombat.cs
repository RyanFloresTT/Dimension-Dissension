using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackTime = 1.0f;
    public float attackDelay = 1.0f;
    public float projectileSpeed = 5.0f;
    public GameObject projPrefab;
    private Player _player;
    private Camera _camera;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireProjectileClip;
    private void Awake()
    {
        _player = Player.Instance;
        _camera = Camera.main;
    }

    private void Update()
    {
        
        if (!_player.isAlive) return;
        if (!Input.GetButton("Fire1")) return;
        if (!(Time.time > attackTime)) return;
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        var direction = (mousePosition - transform.position).normalized;
        Attack(direction);
        attackTime = Time.time + attackDelay;
    }

    private void Attack(Vector3 direction)
    {
        PlayAttackAudio();
        var projectile = Instantiate(projPrefab, transform.position, Quaternion.identity);
        var angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
        var projectileComponent = projectile.GetComponent<PlayerProjectile>();
        projectileComponent.direction = direction;
        projectileComponent.speed = projectileSpeed;
        projectileComponent.owner = gameObject;
        Destroy(projectile, 2);
    }

    private void PlayAttackAudio()
    {
        audioSource.PlayOneShot(fireProjectileClip);
    }
}
