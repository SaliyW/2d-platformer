using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _currentHealth = 100;
    [SerializeField] protected int _maxHealth = 100;
    [SerializeField] protected HealthBar _barSlider;

    protected const int MinHealth = 0;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public Action<float> CurrentValueChanged;
}