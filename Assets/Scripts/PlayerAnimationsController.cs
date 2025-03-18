using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
public class PlayerAnimationsController : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string IsMoving = nameof(IsMoving);
    private const string IsFlying = nameof(IsFlying);

    private int _jumpHash;
    private int _isMovingHash;
    private int _isFlyingHash;
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();

        SetupParametersHash();
    }

    private void Update()
    {
        _animator.SetBool(_isMovingHash, _mover.IsMoving);
        _animator.SetBool(_isFlyingHash, _jumper.IsFlying);
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