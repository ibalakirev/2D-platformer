using TMPro;
using UnityEngine;

public class CounterUseVampirism : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismSkill;
    [SerializeField] private TextMeshProUGUI _indicator;

    private void OnEnable()
    {
        _vampirismSkill.SkillEnabled += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        _vampirismSkill.SkillEnabled -= ChangeValueIndicator;
    }

    private void ChangeValueIndicator()
    {
        _indicator.text = $"{_vampirismSkill.CounterDurationSkill}";
    }
}
