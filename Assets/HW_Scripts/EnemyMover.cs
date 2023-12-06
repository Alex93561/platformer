using UnityEngine;
using UnityEngine.Events;

public class EnemyMover : Mover
{
    [SerializeField] private float _maxMovementRight = 1;
    [SerializeField] private float _maxMovementLeft = -1;
    [SerializeField] private float _speed = 4;

    public override event UnityAction<Vector2> EventDirection;
    public override event UnityAction<float> EventSpeed;

    private Vector3 _rightEndPoint;
    private Vector3 _leftEndPoint;

    private Transform _transform;
    private Vector2 _currentVector2;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        _rightEndPoint = new Vector3(
            _transform.position.x + _maxMovementRight,
            _transform.position.y,
            _transform.position.z);

        _leftEndPoint = new Vector3(
            _transform.position.x +
            _maxMovementLeft, _transform.position.y,
            _transform.position.z);

        _currentVector2 = Vector2.right;
    }

    private void Update()
    {
        _currentVector2 = ChangeDirection();
        EventDirection?.Invoke(_currentVector2);
        EventSpeed?.Invoke(_speed);
    }

    private Vector2 ChangeDirection()
    {
        Vector2 vector2;

        if (_transform.position.x >= _rightEndPoint.x)
        {
            vector2 = Vector2.left;
        }
        else if (_transform.position.x <= _leftEndPoint.x)
        {
            vector2 = Vector2.right;
        }
        else
        {
            vector2 = _currentVector2;
        }

        return vector2;
    }
}