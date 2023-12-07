using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _jumpSpeed = 5f;

    [SerializeField] private UserInput _userInput;
    [SerializeField] private CollisionHandler _playerColliderManager;

    private Coroutine _jumpCoroutine;
    private Rigidbody2D _rigidbody2D;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _userInput.Jump += Jump;
        _playerColliderManager.IsGround += ChangeGround;
        _playerColliderManager.IsHitCeiling += Stop;
    }

    private void OnDisable()
    {
        _userInput.Jump -= Jump;
        _playerColliderManager.IsGround -= ChangeGround;
        _playerColliderManager.IsHitCeiling -= Stop;
    }

    private void Jump()
    {
        if (_isGround)
        {
            _jumpCoroutine = StartCoroutine(JumpCoroutine());
        }
    }

    public void Stop(bool isHitCeiling)
    {
        if (_jumpCoroutine != null && isHitCeiling)
        {
            _rigidbody2D.gravityScale = 1;
            StopCoroutine(_jumpCoroutine);
        }
    }

    private void ChangeGround(bool isGround)
    {
        _isGround = isGround;
    }

    private IEnumerator JumpCoroutine()
    {
        float tempJumpHeight = _jumpHeight;
        _rigidbody2D.gravityScale = 0;

        while (tempJumpHeight > 0)
        {
            transform.position += transform.up * _jumpHeight * Time.deltaTime * _jumpSpeed;
            tempJumpHeight -= _jumpHeight * Time.deltaTime * _jumpSpeed;

            yield return Time.deltaTime;
        }

        _rigidbody2D.gravityScale = 1;
        StopCoroutine(_jumpCoroutine);
    }
}