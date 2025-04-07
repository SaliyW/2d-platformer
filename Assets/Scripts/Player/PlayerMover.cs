using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
[RequireComponent(typeof(PlayerAnimations))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 8;

    private PlayerInputReader _inputReader;
    private PlayerSurfaceChecker _surfaceChecker;
    private PlayerAnimations _animations;

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _surfaceChecker = GetComponent<PlayerSurfaceChecker>();
        _animations = GetComponent<PlayerAnimations>();
    }

    public void TryMove()
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

        _animations.SetMoving(input.x != 0);
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