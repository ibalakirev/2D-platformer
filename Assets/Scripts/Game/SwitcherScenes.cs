using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitcherScenes : MonoBehaviour
{
    [SerializeField] private Button _buttonOpenScene;
    [SerializeField] private string _nameScene;

    private void OnEnable()
    {
        _buttonOpenScene?.onClick.AddListener(OpenScene);
    }

    private void OnDisable()
    {
        _buttonOpenScene?.onClick.RemoveListener(OpenScene);
    }

    protected void OpenScene()
    {
        float maxValueTime = 1f;

        Time.timeScale = maxValueTime;

        SceneManager.LoadScene(_nameScene);
    }
}
