using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private IMover _mover;
    private float _speed;

    private void Awake()
    {
        _mover = GetComponent<IMover>();
    }

    private void OnEnable()
    {
        _mover.SpeedChanged += SetSpeed;
        _mover.DirectionChanged += Move;
    }

    private void OnDisable()
    {
        _mover.SpeedChanged += SetSpeed;
        _mover.DirectionChanged += Move;
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void SetSpeed(float speed)
    {
        _speed = speed;
    }
}