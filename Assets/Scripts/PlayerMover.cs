using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private PlayerInputReader _inputReader;
    private SpriteRenderer _spriteRenderer;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
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
}