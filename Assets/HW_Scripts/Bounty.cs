using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bounty : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;
    [SerializeField] private AudioSource _audioSource;

    private Collider2D _collider;
    private WaitForSeconds _sleep;
    private Coroutine _coroutine;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _sleep = new WaitForSeconds(_animationClip.length - 0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<UserInput>(out _))
        {
            _collider.enabled = false;
            _audioSource.Play();
            _animator.SetTrigger(Parametrs.Trigers.PickUp);
            _coroutine = StartCoroutine(DisabledCoin());
        }
    }

    private IEnumerator DisabledCoin()
    {
        yield return _sleep;
        gameObject.SetActive(false);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}