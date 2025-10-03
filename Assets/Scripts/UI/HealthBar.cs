using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _delta = 0.2f;

    private Slider _slider;
    private Quaternion _fixedRotation;
    Coroutine _coroutine;

    public Slider Slider => _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _fixedRotation = _slider.transform.rotation;
    }

    public void LockRotation()
    {
        _slider.transform.rotation = _fixedRotation;
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
    }
}