public class EnemyHealth : Health
{
    private void Start()
    {
        _barSlider.Slider.maxValue = MaxHealth;
        _barSlider.Slider.value = CurrentHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < _minHealth)
        {
            _currentHealth = _minHealth;
        }

        CurrentValueChanged?.Invoke(_currentHealth);
    }
}