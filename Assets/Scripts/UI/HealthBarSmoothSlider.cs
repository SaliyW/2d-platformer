using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSmoothSlider : MonoBehaviour
{
    [SerializeField] private Slider _sliderDisplay;
    [SerializeField] private float _delta = 0.2f;

    private Health _health;
    private Quaternion _fixedRotation;
    private Coroutine _coroutine;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _sliderDisplay.maxValue = _health.MaxHealth;
        _sliderDisplay.value = _health.CurrentHealth;
        _fixedRotation = _sliderDisplay.transform.rotation;
    }

    public void DisplayChangedHealth()
    {
        _coroutine = StartCoroutine(Display());
    }

    public void LockRotation()
    {
        _sliderDisplay.transform.rotation = _fixedRotation;
    }

    private IEnumerator Display()
    {
        WaitForEndOfFrame wait = new();

        while (_sliderDisplay.value != _health.CurrentHealth)
        {
            _sliderDisplay.value = Mathf.MoveTowards(_sliderDisplay.value, _health.CurrentHealth, _delta);

            yield return wait;
        }
    }
}