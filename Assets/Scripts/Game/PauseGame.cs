using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _canvasMenu;
    [SerializeField] private GameObject _player;

    public void EnablePauseGame()
    {
        float minValueTime = 0f;

        _canvasMenu.SetActive(true);
        _player.SetActive(false);
        gameObject.SetActive(false);

        Time.timeScale = minValueTime;
    }
}
