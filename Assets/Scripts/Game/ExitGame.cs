using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private Button _buttonExitGame;

    private void OnEnable()
    {
        _buttonExitGame.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _buttonExitGame.onClick.RemoveListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
