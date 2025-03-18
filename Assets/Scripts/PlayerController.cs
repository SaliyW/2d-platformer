using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpForce = 1150;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimationsController _animationsController;
    private PlayerGroundChecker _groundChecker;
    private InputReader _inputReader;

    public bool IsFlying { get; private set; }
    public bool IsMoving { get; private set; }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animationsController = GetComponent<PlayerAnimationsController>();
        _groundChecker = GetComponent<PlayerGroundChecker>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        Move();
        Jump();
        FlyingControl();
    }

    private void Move()
    {
        Vector3 input = _inputReader.ReadHorizontalInput();

        transform.position += _speed * Time.deltaTime * input;
        IsMoving = input.x != 0;

        if (IsMoving)
        {
            _spriteRenderer.flipX = input.x <= 0;
        }
    }

    private void Jump()
    {
        if (_inputReader.IsJumpKeyDown() && _groundChecker.IsGrounded())
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
            _animationsController.SetJump();
        }
    }

    private void FlyingControl()
    {
        IsFlying = _rigidbody.velocity.y < 0;
    }
}