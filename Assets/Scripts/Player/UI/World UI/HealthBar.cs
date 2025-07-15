using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDisplay;
    [SerializeField] private Slider _sliderDisplay;
    [SerializeField] private bool _useSmoothSlider = false;

    private PlayerHealth _playerHealth;

    void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _sliderDisplay.maxValue = _playerHealth.MaxHealth;
    }

    void Update()
    {
        TextDisplay();
        SliderDisplay();
    }

    private void TextDisplay()
    {
            _textDisplay.text = $"{_playerHealth.CurrentHealth}/{_playerHealth.MaxHealth}";

    }

    private void SliderDisplay()
    {
        if (_useSmoothSlider)
        {
            _sliderDisplay.value = Mathf.MoveTowards(_sliderDisplay.value, _playerHealth.CurrentHealth, 0.05f);
        }
        else
        {
            _sliderDisplay.value = _playerHealth.CurrentHealth;
        }
    }
}
