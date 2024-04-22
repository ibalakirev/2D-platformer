using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private Coroutine _coroutineSlider;

    private void OnEnable()
    {
        _health.CurrentValueReduce += ChangeValueIndicator;
        _health.CurrentValueIncreas += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        _health.CurrentValueReduce -= ChangeValueIndicator;
        _health.CurrentValueIncreas -= ChangeValueIndicator;
    }

    private void ChangeValueIndicator()
    {
        if (_coroutineSlider != null)
        {
            StopCoroutine(_coroutineSlider);
        }

        _coroutineSlider = StartCoroutine(ShiftSlowlyValueSlider());
    }

    private IEnumerator ShiftSlowlyValueSlider()
    {
        float valueSlider = _slider.value;
        float valueTarget = GetCurrentValueForSlider();
        float speedFillHealthBar = 1f;
        float delay = 1f;

        for (float i = 0; i < delay; i += speedFillHealthBar * Time.deltaTime)
        {
            yield return null;

            _slider.value = Mathf.Lerp(valueSlider, valueTarget, i);
        }

        _slider.value = valueTarget;
    }

    private float GetCurrentValueForSlider()
    {
        return _health.CurrentValue / _health.MaxValue;
    }
}
