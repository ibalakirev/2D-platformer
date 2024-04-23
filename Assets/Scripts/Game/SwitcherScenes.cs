using UnityEngine;
using UnityEngine.UI;

public abstract class SwitcherScenes : MonoBehaviour
{
    [SerializeField] private Button _buttonOpenScene;

    private void OnEnable()
    {
        _buttonOpenScene?.onClick.AddListener(OpenScene);
    }

    private void OnDisable()
    {
        _buttonOpenScene?.onClick.RemoveListener(OpenScene);
    }

    protected abstract void OpenScene();
}
