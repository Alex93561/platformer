using UnityEngine;
using UnityEngine.Events;

public class EnemyMover : Mover
{
    [SerializeField] private float _maxMovementRight = 1;
    [SerializeField] private float _maxMovementLeft = -1;
    [SerializeField] private float _speed = 4;

    public override event UnityAction<Vector2> DirectionChanged;
    public override event UnityAction<float> SpeedChanged;

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