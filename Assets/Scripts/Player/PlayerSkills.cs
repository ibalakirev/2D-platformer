using UnityEngine;

[RequireComponent(typeof(InputReader))]

public abstract class PlayerSkills : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    protected InputReader InputReader => _inputReader;

    private void Update()
    {
        if (GetInputUseSkill())
        {
            UseSkill();
        }
    }

    protected abstract bool GetInputUseSkill();

    protected abstract void UseSkill();
}
