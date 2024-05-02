using UnityEngine;

public class SwitcherObjectsVampirism : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private GameObject _timeIndicatorAbility;
    [SerializeField] private GameObject _imageAbility;

    private void OnEnable()
    {
        _vampirismAbility.SkillEnabled += EnableObjectsAbility;
        _vampirismAbility.SkillDisabled += DisableObjectsAbility;
    }

    private void OnDisable()
    {
        _vampirismAbility.SkillEnabled -= EnableObjectsAbility;
        _vampirismAbility.SkillDisabled -= DisableObjectsAbility;
    }

    private void EnableObjectsAbility()
    {
        _timeIndicatorAbility.SetActive(true);
        _imageAbility.SetActive(true);
    }

    private void DisableObjectsAbility()
    {
        _timeIndicatorAbility.SetActive(false);
        _imageAbility.SetActive(false);
    }
}
