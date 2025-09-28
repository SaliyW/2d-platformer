using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerVampirism : MonoBehaviour
{
    [SerializeField] private BarSlider _barSlider;
    [SerializeField] private CircleOfVampirism _circleOfVampirism;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _currentActionTime;
    [SerializeField] private float _currentRechargeTime;

    public Action<float> CurrentValueChanged;
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

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _health = GetComponent<PlayerHealth>();
        _circleOfVampirism.gameObject.SetActive(false);
        _currentActionTime = _maxActionTime;
        _currentRechargeTime = _maxRechargeTime;
    }

    private void Start()
    {
        _barSlider.Slider.maxValue = MaxActionTime;
        _barSlider.Slider.value = CurrentActionTime;
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

        _barSlider.Slider.maxValue = _currentActionTime;
        _circleOfVampirism.gameObject.SetActive(true);

        while (_currentActionTime != _minCountValue)
        {
            if (_circleOfVampirism.GiveTarget() != null)
            {
                enemyHealth = _circleOfVampirism.GiveTarget().GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(_damage);
                _health.TakeHeal(_damage);
            }

            _currentActionTime--;
            CurrentValueChanged?.Invoke(_currentActionTime);

            yield return wait;
        }

        _currentRechargeTime = _minCountValue;
        _barSlider.Slider.maxValue = MaxRechargeTime;
        CurrentValueChanged?.Invoke(_currentRechargeTime);
        _coroutine = StartCoroutine(CountRecharge());
    }

    private IEnumerator CountRecharge()
    {
        WaitForSecondsRealtime wait = new(1);

        _circleOfVampirism.gameObject.SetActive(false);

        while (_currentRechargeTime != _maxRechargeTime)
        {
            _currentRechargeTime++;
            CurrentValueChanged?.Invoke(_currentRechargeTime);

            yield return wait;
        }

        _currentActionTime = _maxActionTime;
        _barSlider.Slider.maxValue = _currentActionTime;
        _barSlider.Slider.value = _barSlider.Slider.maxValue;
    }
}