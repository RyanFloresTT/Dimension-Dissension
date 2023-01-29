using UnityEngine;

public class StartMenuEnemyAI : MonoBehaviour
{

    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private float movementSpeed;
    private bool _goingLeft = true;

    // Update is called once per frame
    private void Update()
    {
        var direction = CalculateDirection();
        
        transform.position += direction * (movementSpeed * Time.deltaTime);

        if (transform.position.x <= leftPosition.position.x || transform.position.x >= rightPosition.position.x)
        {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        _goingLeft = !_goingLeft;
    }

    private Vector3 CalculateDirection()
    {
        if (_goingLeft)
        {
            var position = leftPosition.position;
            return new Vector3(position.x, 0, 0).normalized;
        }
        else
        {
            var position = rightPosition.position;
            return new Vector3(position.x, 0, 0).normalized;
        }
    }

}
