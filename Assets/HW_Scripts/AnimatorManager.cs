using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;
    [SerializeField] private string _floatParametrName;

    private void OnEnable()
    {
        _mover.EventDirection += Look;
        _mover.EventSpeed += SetSpeed;
    }

    private void OnDisable()
    {
        _mover.EventDirection -= Look;
        _mover.EventSpeed -= SetSpeed;
    }

    private void Look(Vector2 direction)
    {
        if (direction == Vector2.right)
        {
            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
        }
        else if (direction == Vector2.left)
        {
            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 1);
        }
    }

    private void SetSpeed(float speed)
    {
        _animator.SetFloat(_floatParametrName, speed);
    }
}