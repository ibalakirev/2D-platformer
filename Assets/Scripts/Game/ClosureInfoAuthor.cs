using UnityEngine;

public class ClosureInfoAuthor : MonoBehaviour
{
    [SerializeField] private GameObject _canvasMenu;

    public void CloseWindowInfoAuthor()
    {
        gameObject.SetActive(false);
        _canvasMenu.SetActive(true);
    }
}
