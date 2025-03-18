using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string IsMoving = nameof(IsMoving);
    private const string IsFlying = nameof(IsFlying);

    private int _jumpHash;
    private int _isMovingHash;
    private int _isFlyingHash;
    private PlayerController _controller;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();

        SetupParametersHash();
    }

    private void Update()
    {
        _animator.SetBool(_isMovingHash, _controller.IsMoving);
        _animator.SetBool(_isFlyingHash, _controller.IsFlying);
    }

    private void SetupParametersHash()
    {
        _jumpHash = Animator.StringToHash(Jump);
        _isMovingHash = Animator.StringToHash(IsMoving);
        _isFlyingHash = Animator.StringToHash(IsFlying);
    }

    public void SetJump()
    {
        _animator.SetTrigger(_jumpHash);
    }
}