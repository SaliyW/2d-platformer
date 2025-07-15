using UnityEngine;

[RequireComponent(typeof(PlayerAnimations))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 3;
    [SerializeField] private int _maxHealth = 3;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private PlayerAnimations _animations;
    private readonly int _damage = 20; //test value for buttons

    private void Awake()
    {
        _animations = GetComponent<PlayerAnimations>();
    }

    public void LoseHealth()
    {
        _animations.SetHurt();

        //_currentHealth--;
        _currentHealth -= _damage;

        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeCherry(GameObject cherry)
    {
        _animations.SetHeal();

        Destroy(cherry);

        Heal();
    }

    public void Heal()
    {
        if (_currentHealth < _maxHealth)
        {
            //_currentHealth++;
            _currentHealth += _damage;
        }
    }
}