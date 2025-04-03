using UnityEngine;

[RequireComponent(typeof(PlayerAnimationsController))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _lives = 3;

    private PlayerAnimationsController _animationsController;

    private void Awake()
    {
        _animationsController = GetComponent<PlayerAnimationsController>();
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

    public void Heal(GameObject cherry)
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