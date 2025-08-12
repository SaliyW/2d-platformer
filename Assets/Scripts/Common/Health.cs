using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _currentHealth = 100;
    [SerializeField] protected int _maxHealth = 100;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public Action HealthChanged;

    protected const int _minHealth = 0;
}