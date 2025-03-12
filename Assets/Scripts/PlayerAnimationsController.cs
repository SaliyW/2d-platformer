using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    private const string JumpTrigger = "Jump";
    private const string IsMoving = "IsMoving";
    private const string IsFlying = "IsFlying";

    private PlayerController _controller;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _animator.SetBool(IsMoving, _controller.IsMoving);
        _animator.SetBool(IsFlying, _controller.IsFlying);
    }
    
    public void Jump()
    {
        _animator.SetTrigger(JumpTrigger);
    }
}