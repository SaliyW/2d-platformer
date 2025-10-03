using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerVampirism : MonoBehaviour
{
    [SerializeField] private VampirismBar _barSlider;
    [SerializeField] private VampirismTargetFinder _targetFinder;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _currentActionTime;
    [SerializeField] private float _currentRechargeTime;

    public Action<float> CurrentValueChanged;
    public Action VampirismActivityChanged;
    private PlayerInputReader _inputReader;
    private PlayerHealth _health;
    private readonly float _maxActionTime = 6;
    private readonly float _maxRechargeTime = 4;
    private readonly float _minCountValue = 0;
    private Coroutine _coroutine;

    public float CurrentActionTime => _currentActionTime;
    public float CurrentRechargeTime => _currentRechargeTime;
    public float MaxActionTime => _maxActionTime;
    public float MaxRechargeTime => _maxRechargeTime;
    public float MinCountValue => _minCountValue;

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _health = GetComponent<PlayerHealth>();
        _currentActionTime = _maxActionTime;
        _currentRechargeTime = _maxRechargeTime;
    }

    public void TryVampirism()
    {
        if (_inputReader.IsVampirismKeyDown() && _currentActionTime == _maxActionTime)
        {       
            _coroutine = StartCoroutine(CountAction());
        }
    }

    private IEnumerator CountAction()
    {
        WaitForSecondsRealtime wait = new(1);
        EnemyHealth enemyHealth = null;

        VampirismActivityChanged?.Invoke();

        while (_currentActionTime != _minCountValue)
        {
            if (_targetFinder.GiveTarget() != null)
            {
                enemyHealth = _targetFinder.GiveTarget().GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(_damage);
                _health.TakeHeal(_damage);
            }

            _currentActionTime--;
            CurrentValueChanged?.Invoke(_currentActionTime);

            yield return wait;
        }

        _currentRechargeTime = _minCountValue;
        CurrentValueChanged?.Invoke(_currentRechargeTime);
        _coroutine = StartCoroutine(CountRecharge());
    }

    private IEnumerator CountRecharge()
    {
        WaitForSecondsRealtime wait = new(1);

        VampirismActivityChanged?.Invoke();

        while (_currentRechargeTime != _maxRechargeTime)
        {
            _currentRechargeTime++;
            CurrentValueChanged?.Invoke(_currentRechargeTime);

            yield return wait;
        }

        _currentActionTime = _maxActionTime;
    }
}