using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject _canvasGame;
    [SerializeField] private GameObject _player;

    public void EnableStartGame()
    {
        float maxValueTime = 1f;

        _canvasGame.SetActive(true);
        _player.SetActive(true);
        gameObject.SetActive(false);

        Time.timeScale = maxValueTime;
    }
}
