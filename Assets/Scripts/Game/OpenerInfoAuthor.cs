using UnityEngine;

public class OpenerInfoAuthor : MonoBehaviour
{
    [SerializeField] private GameObject _infoAuthor;

    public void OpenInfoAuthor()
    {
        _infoAuthor.SetActive(true);
    }
}
