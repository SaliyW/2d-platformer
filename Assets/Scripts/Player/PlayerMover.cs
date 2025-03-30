using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 8;

    private PlayerInputReader _inputReader;
    private PlayerSurfaceChecker _surfaceChecker;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _surfaceChecker = GetComponent<PlayerSurfaceChecker>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float currentSpeed;
        float slowSpeed = 0.5f;

        if (_surfaceChecker.IsWallAhead())
        {
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = _speed;
        }

        Vector3 input = _inputReader.ReadHorizontalInput();

        transform.position += currentSpeed * Time.deltaTime * input;
        IsMoving = input.x != 0;

        TryTurnAround(input);
    }

    private void TryTurnAround(Vector3 input)
    {
        Quaternion leftTurn = Quaternion.Euler(0, 180, 0);
        Quaternion rightTurn = Quaternion.Euler(Vector3.zero);

        if (input.x < 0)
        {
            transform.rotation = leftTurn;
        }
        else if (input.x > 0)
        {
            transform.rotation = rightTurn;
        }
    }
}