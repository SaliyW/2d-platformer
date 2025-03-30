using UnityEngine;

[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(PlayerCollisionDetector))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _lives = 3;

    private PlayerAnimationsController _animationsController;
    private PlayerCollisionDetector _collisionDetector;

    private void Awake()
    {
        _animationsController = GetComponent<PlayerAnimationsController>();
        _collisionDetector = GetComponent<PlayerCollisionDetector>();
    }

    private void OnEnable()
    {
        _collisionDetector.CherryTriggerEntered += Heal;
    }

    private void OnDisable()
    {
        _collisionDetector.CherryTriggerEntered -= Heal;
    }

    public void LoseLife()
    {
        _animationsController.SetHurt();

        _lives--;

        if (_lives == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Heal(GameObject cherry)
    {
        int maxLives = 3;

        _animationsController.SetHeal();

        Destroy(cherry);

        if (_lives < maxLives)
        {
            _lives++;
        }
    }
}