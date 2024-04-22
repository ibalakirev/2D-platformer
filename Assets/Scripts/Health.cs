using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 100f;

    public event Action CurrentValueIncreas;
    public event Action CurrentValueReduce;
    public event Action DeathReport;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;
    public bool IsLive => _currentValue > _minValue;

    public void ReduceCurrentValue(float damage)
    {
        float multiplierDamage = -1;
        float damageValue = damage * multiplierDamage;

        if (IsLive && IsIncomingValue(damage))
        {
            ChangeCurrentValue(damageValue);

            CurrentValueReduce?.Invoke();

            TryDeath();
        }
    }

    public void IncreaseCurrentValue(float healthMedkit)
    {
        if (IsLive && IsIncomingValue(healthMedkit))
        {
            ChangeCurrentValue(healthMedkit);

            CurrentValueIncreas?.Invoke();
        }
    }

    private void ChangeCurrentValue(float valueIncoming)
    {
        _currentValue += valueIncoming;

        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
    }

    private bool IsIncomingValue(float valueIncoming)
    {
        float minValueIncoming = 0f;

        return valueIncoming > minValueIncoming;
    }

    private void TryDeath()
    {
        if (IsLive == false)
        {
            DeathReport?.Invoke();
        }
    }
}

