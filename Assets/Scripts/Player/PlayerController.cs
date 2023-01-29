using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private SpriteRenderer _spriteRenderer;
    private bool _facingLeft = false;
    private Player _player;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = Player.Instance;
    }

    private void Update()
    {
        if (!_player.isAlive) return;
        float horizontalInput = 0;
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1;
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1;
        if (Input.GetKey(KeyCode.W)) verticalInput = 1;
        if (Input.GetKey(KeyCode.S)) verticalInput = -1;

        switch (horizontalInput)
        {
            case < 0 when !_facingLeft:
                _spriteRenderer.flipX = true;
                _facingLeft = true;
                break;
            case > 0 when _facingLeft:
                _spriteRenderer.flipX = false;
                _facingLeft = false;
                break;
        }
        var direction = new Vector3(horizontalInput, verticalInput, 0).normalized;

        transform.position += direction * (movementSpeed * Time.deltaTime);
    }
}
