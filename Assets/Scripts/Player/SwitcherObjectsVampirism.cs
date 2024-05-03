using UnityEngine;

public class SwitcherObjectsVampirism : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private Canvas _timeIndicatorAbility;
    [SerializeField] private SpriteRenderer _imageAbility;

    private void OnEnable()
    {
        _vampirismAbility.StealHealthIterated += EnableImageAbility;
        _vampirismAbility.StealHealthDisabled += DisableImageAbility;
        _vampirismAbility.CooldownIterated += EnableTimerCooldownAbility;
        _vampirismAbility.CooldownDisabled += DisableTimerCooldownAbility;
    }

    private void OnDisable()
    {
        _vampirismAbility.CooldownIterated -= EnableImageAbility;
        _vampirismAbility.CooldownDisabled -= DisableImageAbility;
        _vampirismAbility.CooldownIterated -= EnableTimerCooldownAbility;
        _vampirismAbility.CooldownDisabled -= DisableTimerCooldownAbility;
    }

    private void EnableTimerCooldownAbility()
    {
        _timeIndicatorAbility.gameObject.SetActive(true);
    }

    private void DisableTimerCooldownAbility()
    {
        _timeIndicatorAbility.gameObject.SetActive(false);
    }

    private void EnableImageAbility()
    {
        _imageAbility.gameObject.SetActive(true);
    }

    private void DisableImageAbility()
    {
        _imageAbility.gameObject.SetActive(false);
    }
}
