using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1150;

    private PlayerInputReader _inputReader;
    private PlayerAnimations _animations;
    private Rigidbody2D _rigidbody;
    private PlayerSurfaceChecker _surfaceChecker;

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _animations = GetComponent<PlayerAnimations>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _surfaceChecker = GetComponent<PlayerSurfaceChecker>();
    }

    public void TryJump()
    {
        if (_inputReader.IsJumpKeyDown() && _surfaceChecker.IsGrounded())
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
            _animations.SetJump();
        }

        _animations.SetFlying(_rigidbody.velocity.y < 0);
    }
}