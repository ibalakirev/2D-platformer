using UnityEngine;

public class SwitcherTimeGame : MonoBehaviour
{
    [SerializeField] GameObject _canvasGame;
    [SerializeField] GameObject _canvasPauseGame;
    [SerializeField] private GameObject _player;

    public void EnableStartGame()
    {
        float maxValueTime = 1f;

        _canvasPauseGame.SetActive(false);
        _canvasGame.SetActive(true);
        _player.SetActive(true);

        Time.timeScale = maxValueTime;
    }

    public void EnablePauseGame()
    {
        float minValueTime = 0f;

        _canvasGame.SetActive(false);
        _player.SetActive(false);
        _canvasPauseGame.SetActive(true);

        Time.timeScale = minValueTime;
    }
}
