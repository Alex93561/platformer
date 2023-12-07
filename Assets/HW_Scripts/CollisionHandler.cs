using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _rayCastDownLength = 0.02f;
    [SerializeField] private float _rayCastUpLength = 0.02f;
    [SerializeField] ContactFilter2D _contactsFilter;

    public event UnityAction<bool> IsGround;
    public event UnityAction<bool> IsHitCeiling;

    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D[] _raycastHits;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _raycastHits = new RaycastHit2D[10];
    }

    private void FixedUpdate()
    {
        int count = _rigidbody2D.Cast(transform.up * -1, _contactsFilter, _raycastHits, _rayCastDownLength);
        IsGround?.Invoke(count > 0);

        count = _rigidbody2D.Cast(transform.up, _contactsFilter, _raycastHits, _rayCastUpLength);
        IsHitCeiling?.Invoke(count > 0);
    }
}