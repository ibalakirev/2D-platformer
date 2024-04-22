using UnityEngine;

public class SwitcherInfoAuthor : MonoBehaviour
{
    [SerializeField] private GameObject _infoAuthor;

    public void OpenInfoAuthor()
    {
        _infoAuthor.SetActive(true);
    }

    public void CloseWindowInfoAuthor()
    {
        _infoAuthor.SetActive(false);
    }
}
