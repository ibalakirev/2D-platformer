using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class IndicatorHealth : MonoBehaviour
{
    [SerializeField] private Health _character;
    [SerializeField] private Slider _slider;

    private Coroutine _coroutineSlider;

    public Health Character => _character;

    protected void ChangeValueIndicator()
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
        return _character.CurrentValue / _character.MaxValue;
    }
}
