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
    private Coroutine _coroutine;

    public float CurrentActionTime => _currentActionTime;
    public float CurrentRechargeTime => _currentRechargeTime;
    public float MaxActionTime => 6;
    public float MaxRechargeTime => 4;
    public float MinCountValue => 0;

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _health = GetComponent<PlayerHealth>();
        _currentActionTime = MaxActionTime;
        _currentRechargeTime = MaxRechargeTime;
    }

    public void TryVampirism()
    {
        if (_inputReader.IsVampirismKeyDown() && _currentActionTime == MaxActionTime)
        {
            _coroutine = StartCoroutine(CountAction());
        }
    }

    private IEnumerator CountAction()
    {
        WaitForSecondsRealtime wait = new(1);

        VampirismActivityChanged?.Invoke();

        while (_currentActionTime > MinCountValue)
        {
            if (_targetFinder.TryGiveTarget(out Enemy enemy))
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(_damage);
                _health.TakeHeal(_damage);
            }

            _currentActionTime--;
            CurrentValueChanged?.Invoke(_currentActionTime);

            yield return wait;
        }

        _currentRechargeTime = MinCountValue;
        CurrentValueChanged?.Invoke(_currentRechargeTime);
        _coroutine = StartCoroutine(CountRecharge());
    }

    private IEnumerator CountRecharge()
    {
        WaitForSecondsRealtime wait = new(1);

        VampirismActivityChanged?.Invoke();

        while (_currentRechargeTime < MaxRechargeTime)
        {
            _currentRechargeTime++;
            CurrentValueChanged?.Invoke(_currentRechargeTime);

            yield return wait;
        }

        _currentActionTime = MaxActionTime;
    }
}