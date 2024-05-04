using TMPro;
using UnityEngine;

public class CooldownIndicatorVampirism : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismSkill;
    [SerializeField] private TextMeshProUGUI _indicator;

    private void OnEnable()
    {
        _vampirismSkill.CooldownIterated += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        _vampirismSkill.CooldownIterated -= ChangeValueIndicator;
    }

    private void ChangeValueIndicator()
    {
        _indicator.text = $"{_vampirismSkill.CurrentValueCooldown}";
    }
}
