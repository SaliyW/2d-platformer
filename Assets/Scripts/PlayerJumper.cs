using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerGroundChecker))]
[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1150;

    private PlayerInputReader _inputReader;
    private PlayerGroundChecker _groundChecker;
    private PlayerAnimationsController _animationsController;
    private Rigidbody2D _rigidbody;

    public bool IsFlying { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _groundChecker = GetComponent<PlayerGroundChecker>();
        _animationsController = GetComponent<PlayerAnimationsController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        ControlFlight();
    }

    private void Jump()
    {
        if (_inputReader.IsJumpKeyDown() && _groundChecker.IsGrounded())
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
            _animationsController.SetJump();
        }
    }

    private void ControlFlight()
    {
        IsFlying = _rigidbody.velocity.y < 0;
    }
}