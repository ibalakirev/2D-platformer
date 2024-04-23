using UnityEngine;
using UnityEngine.UI;

public class SwitcherInfoAuthor : MonoBehaviour
{
    [SerializeField] private GameObject _infoAuthor;
    [SerializeField] private Button _buttonOpenInfoAuthor;
    [SerializeField] private Button _buttonCloseWindowInfoAuthor;

    private void OnEnable()
    {
        _buttonOpenInfoAuthor.onClick.AddListener(OpenInfoAuthor);
        _buttonCloseWindowInfoAuthor.onClick.AddListener(CloseWindowInfoAuthor);
    }

    private void OnDisable()
    {
        _buttonOpenInfoAuthor.onClick.RemoveListener(OpenInfoAuthor);
        _buttonCloseWindowInfoAuthor.onClick.RemoveListener(CloseWindowInfoAuthor);
    }

    private void OpenInfoAuthor()
    {
        _infoAuthor.SetActive(true);
    }

    private void CloseWindowInfoAuthor()
    {
        _infoAuthor.SetActive(false);
    }
}
