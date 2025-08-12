using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimations))]
public class PlayerHealth : Health
{
    private PlayerAnimations _animations;

    private void Awake()
    {
        _animations = GetComponent<PlayerAnimations>();
    }

    public void TakeDamage(int damage)
    {
        _animations.SetHurt();

        _currentHealth -= damage;

        if (_currentHealth < _minHealth)
        {
            _currentHealth = _minHealth;
        }

        HealthChanged?.Invoke();
    }

    public void TakeCherry(Cherry cherry)
    {
        TakeHeal(cherry.HealValue);
        Destroy(cherry.gameObject);
    }

    public void TakeHeal(int heal)
    {
        _animations.SetHeal();

        _currentHealth += heal;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        HealthChanged?.Invoke();
    }
}