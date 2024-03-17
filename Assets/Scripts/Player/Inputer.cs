using UnityEngine;

public class Inputer : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _horizontalAxis = 0;

    public float HorizontalAxis => _horizontalAxis;

    private void Update()
    {
        _horizontalAxis = Input.GetAxis(Horizontal);

        GetJump();
    }

    public bool GetJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
