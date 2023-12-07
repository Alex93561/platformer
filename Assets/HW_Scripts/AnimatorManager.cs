using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;

    private void OnEnable()
    {
        _mover.DirectionChanged += Look;
        _mover.SpeedChanged += SetSpeed;
    }

    private void OnDisable()
    {
        _mover.DirectionChanged -= Look;
        _mover.SpeedChanged -= SetSpeed;
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
        _animator.SetFloat(Parametrs.Params.Speed, speed);
    }
}