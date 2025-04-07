using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private const string Hurt = nameof(Hurt);
    private const string Heal = nameof(Heal);
    private const string Jump = nameof(Jump);
    private const string IsMoving = nameof(IsMoving);
    private const string IsFlying = nameof(IsFlying);

    private int _hurtHash;
    private int _healHash;
    private int _jumpHash;
    private int _isMovingHash;
    private int _isFlyingHash;
    private bool _isMoving;
    private bool _isFlying;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        SetupParametersHash();
    }

    private void Update()
    {
        _animator.SetBool(_isMovingHash, _isMoving);
        _animator.SetBool(_isFlyingHash, _isFlying);
    }

    private void SetupParametersHash()
    {
        _hurtHash = Animator.StringToHash(Hurt);
        _healHash = Animator.StringToHash(Heal);
        _jumpHash = Animator.StringToHash(Jump);
        _isMovingHash = Animator.StringToHash(IsMoving);
        _isFlyingHash = Animator.StringToHash(IsFlying);
    }

    public void SetMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }

    public void SetFlying(bool isFlying)
    {
        _isFlying = isFlying;
    }

    public void SetJump()
    {
        _animator.SetTrigger(_jumpHash);
    }

    public void SetHurt()
    {
        _animator.SetTrigger(_hurtHash);
    }

    public void SetHeal()
    {
        _animator.SetTrigger(_healHash);
    }
}