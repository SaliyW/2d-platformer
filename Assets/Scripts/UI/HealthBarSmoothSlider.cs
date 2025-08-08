using UnityEngine;
using UnityEngine.UI;

public class HealthBarSmoothSlider : MonoBehaviour
{
    [SerializeField] private Slider _sliderDisplay;

    private Health _health;
    private Quaternion _fixedRotation;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _sliderDisplay.maxValue = _health.MaxHealth;
        _fixedRotation = _sliderDisplay.transform.rotation;
    }

    private void Update()
    {
        SliderDisplaySmoothly();
    }

    private void LateUpdate()
    {
        _sliderDisplay.transform.rotation = _fixedRotation;
    }

    private void SliderDisplaySmoothly()
    {
        _sliderDisplay.value = Mathf.MoveTowards(_sliderDisplay.value, _health.CurrentHealth, 0.05f);
    }
}