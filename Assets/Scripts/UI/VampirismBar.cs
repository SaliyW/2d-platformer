using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismBar : MonoBehaviour
{
    [SerializeField] PlayerVampirism _vampirism;
    [SerializeField] private float _delta = 0.2f;

    private Slider _slider;
    Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.maxValue = _vampirism.MaxActionTime;
        _slider.value = _vampirism.CurrentActionTime;
    }

    public void DisplayChangedValue(float target)
    {
        _coroutine = StartCoroutine(Display(target));
    }

    private IEnumerator Display(float target)
    {
        WaitForEndOfFrame wait = new();

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _delta);

            yield return wait;
        }

        if (_vampirism.CurrentRechargeTime == _vampirism.MinCountValue)
        {
            _slider.maxValue = _vampirism.MaxRechargeTime;
        }
        else if (_vampirism.CurrentRechargeTime == _vampirism.MaxRechargeTime && _slider.maxValue == _vampirism.MaxRechargeTime)
        {
            _slider.maxValue = _vampirism.MaxActionTime;
            _slider.value = _slider.maxValue;
        }
    }
}