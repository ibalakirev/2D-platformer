using UnityEngine;

[RequireComponent(typeof(InputReader))]

public abstract class PlayerSkills : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public InputReader InputReader => _inputReader;

    private void Update()
    {
        if (SetInputUseSkill())
        {
            UseSkill();
        }
    }

    protected abstract bool SetInputUseSkill();

    protected abstract void UseSkill();
}
