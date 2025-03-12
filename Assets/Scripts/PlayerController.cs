using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpForce = 1100;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _groundLayer;

    private const string Horizontal = "Horizontal";

    private Vector3 _input;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimationsController _animationsController;
    private bool _isFlying;
    private bool _isMoving;

    public bool IsFlying => _isFlying;
    public bool IsMoving => _isMoving;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animationsController = GetComponent<PlayerAnimationsController>();
    }

    private void Update()
    {
        Move();
        Jump();
        FlyingControl();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * _castDistance, _boxSize);
    }

    private void Move()
    {
        _input.x = Input.GetAxis(Horizontal);
        transform.position += _speed * Time.deltaTime * _input;
        _isMoving = _input.x != 0;

        if (_isMoving)
        {
            _spriteRenderer.flipX = _input.x <= 0;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody.AddForce(transform.up * _jumpForce);

            _animationsController.Jump();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, _boxSize, 0, -transform.up, _castDistance, _groundLayer);
    }

    private void FlyingControl()
    {
        _isFlying = _rigidbody.velocity.y < 0;
    }
}