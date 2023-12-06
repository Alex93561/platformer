using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private float _speed;

    private void OnEnable()
    {
        _mover.EventSpeed += SetSpeed;
        _mover.EventDirection += Move;
    }

    private void Move(Vector2 arg0)
    {
        transform.Translate(arg0 * _speed * Time.deltaTime);
    }

    private void SetSpeed(float arg0)
    {
        _speed = arg0;
    }

    private void OnDisable()
    {
        _mover.EventSpeed += SetSpeed;
        _mover.EventDirection += Move;
    }
}