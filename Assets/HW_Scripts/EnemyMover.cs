using UnityEngine;
using UnityEngine.Events;

public class EnemyMover : MonoBehaviour, IMover
{
    [SerializeField] private float _maxMovementRight = 1;
    [SerializeField] private float _maxMovementLeft = -1;
    [SerializeField] private float _speed = 4;

    public event UnityAction<Vector2> DirectionChanged;
    public event UnityAction<float> SpeedChanged;
    public event UnityAction Jump;

    private Vector3 _rightEndPoint;
    private Vector3 _leftEndPoint;
    private Vector2 _currentDirection;

    private void Start()
    {
        _rightEndPoint = new Vector3(
            transform.position.x + _maxMovementRight,
            transform.position.y,
            transform.position.z);

        _leftEndPoint = new Vector3(
            transform.position.x +
            _maxMovementLeft, transform.position.y,
            transform.position.z);

        _currentDirection = Vector2.right;
    }

    private void Update()
    {
        _currentDirection = GetDirection();
        DirectionChanged?.Invoke(_currentDirection);
        SpeedChanged?.Invoke(_speed);
    }

    private Vector2 GetDirection()
    {
        Vector2 direction;

        if (transform.position.x >= _rightEndPoint.x)
        {
            direction = Vector2.left;
        }
        else if (transform.position.x <= _leftEndPoint.x)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = _currentDirection;
        }

        return direction;
    }
}