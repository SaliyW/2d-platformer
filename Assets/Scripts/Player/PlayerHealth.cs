using UnityEngine;

[RequireComponent(typeof(PlayerAnimations))]
public class PlayerHealth : Health
{
    private PlayerAnimations _animations;

    private void Awake()
    {
        _animations = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        _barSlider.Slider.maxValue = MaxHealth;
        _barSlider.Slider.value = CurrentHealth;
    }

    public void TakeDamage(int damage)
    {
        _animations.SetHurt();

        _currentHealth -= damage;

        if (_currentHealth < MinHealth)
        {
            _currentHealth = MinHealth;
        }

        CurrentValueChanged?.Invoke(_currentHealth);
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

        CurrentValueChanged?.Invoke(_currentHealth);
    }
}