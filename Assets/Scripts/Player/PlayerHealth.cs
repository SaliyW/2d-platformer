using UnityEngine;

[RequireComponent(typeof(PlayerAnimations))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _lives = 3;

    private PlayerAnimations _animations;

    private void Awake()
    {
        _animations = GetComponent<PlayerAnimations>();
    }

    public void LoseLife()
    {
        _animations.SetHurt();

        _lives--;

        if (_lives == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(GameObject cherry)
    {
        int maxLives = 3;

        _animations.SetHeal();

        Destroy(cherry);

        if (_lives < maxLives)
        {
            _lives++;
        }
    }
}