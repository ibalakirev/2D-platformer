using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : IndicatorHealth
{
    private Coroutine _coroutineSlider;

    private void OnEnable()
    {
        Character.CurrentValueReduce += ChangeValueIndicator;
        Character.CurrentValueIncreas += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        Character.CurrentValueReduce -= ChangeValueIndicator;
        Character.CurrentValueIncreas -= ChangeValueIndicator;
    }

    protected override void ChangeValueIndicator()
    {
        if (_coroutineSlider != null)
        {
            StopCoroutine(_coroutineSlider);
        }

        _coroutineSlider = StartCoroutine(ShiftSlowlyValueSlider());
    }

    private IEnumerator ShiftSlowlyValueSlider()
    {
        float valueSlider = Slider.value;
        float valueTarget = GetCurrentValueForSlider();
        float speedFillHealthBar = 1f;
        float delay = 1f;

        for (float i = 0; i < delay; i += speedFillHealthBar * Time.deltaTime)
        {
            yield return null;

            Slider.value = Mathf.Lerp(valueSlider, valueTarget, i);
        }

        Slider.value = valueTarget;
    }
}
