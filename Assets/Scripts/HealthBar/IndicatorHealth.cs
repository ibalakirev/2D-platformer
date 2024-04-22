using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class IndicatorHealth : MonoBehaviour
{
    [SerializeField] private Health _character;

    private Slider _slider;
    public Health Character => _character;
    public Slider Slider => _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    protected abstract void ChangeValueIndicator();

    protected float GetCurrentValueForSlider()
    {
        return _character.CurrentValue / _character.MaxValue;
    }
}
