using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _horizontalAxis = 0;

    public float HorizontalAxis => _horizontalAxis;

    private void Update()
    {
        _horizontalAxis = Input.GetAxis(Horizontal);
    }

    public bool GetInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool GetInputAttack()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool GetInputVampirismSkill()
    {
        return Input.GetKeyDown(KeyCode.R);
    }
}
