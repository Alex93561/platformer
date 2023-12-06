using UnityEngine;
using UnityEngine.Events;

public class PlayerColliderManager : MonoBehaviour
{
    [SerializeField] private float _rayCastDownLength = 0.02f;
    [SerializeField] private float _rayCastUpLength = 0.02f;

    public event UnityAction<bool> IsGround;
    public event UnityAction<bool> IsHitCeiling;

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;

    private RaycastHit2D[] _raycastHit2Ds;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _raycastHit2Ds = new RaycastHit2D[10];
    }

    private void FixedUpdate()
    {
        int count = _rigidbody2D.Cast(_transform.up * -1, _raycastHit2Ds, _rayCastDownLength);
        IsGround?.Invoke(count > 0);

        count = _rigidbody2D.Cast(_transform.up, _raycastHit2Ds, _rayCastUpLength);
        IsHitCeiling?.Invoke(count > 0);
    }
}