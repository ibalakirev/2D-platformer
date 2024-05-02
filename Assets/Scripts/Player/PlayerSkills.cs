using UnityEngine;

[RequireComponent (typeof(InputReader))]

public abstract class PlayerSkills : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public InputReader InputReader => _inputReader;

    void Update()
    {
        if (SetInput())
        {
            UseSkill();
        }
    }

    protected abstract bool SetInput();

    protected abstract void UseSkill();
}
