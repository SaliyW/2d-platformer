using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1150;

    private PlayerInputReader _inputReader;
    private PlayerAnimationsController _animationsController;
    private Rigidbody2D _rigidbody;
    private PlayerSurfaceChecker _surfaceChecker;

    public bool IsFlying { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _animationsController = GetComponent<PlayerAnimationsController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _surfaceChecker = GetComponent<PlayerSurfaceChecker>();
    }

    private void Update()
    {
        Jump();
        ControlFlight();
    }

    private void Jump()
    {
        if (_inputReader.IsJumpKeyDown() && _surfaceChecker.IsGrounded())
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