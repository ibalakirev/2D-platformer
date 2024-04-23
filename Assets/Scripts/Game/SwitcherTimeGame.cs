using UnityEngine;
using UnityEngine.UI;

public class SwitcherTimeGame : MonoBehaviour
{
    [SerializeField] private GameObject _canvasGame;
    [SerializeField] private GameObject _canvasPauseGame;
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _buttonEnableStartGame;
    [SerializeField] private Button _buttonEnablePauseGame;

    private void OnEnable()
    {
        _buttonEnableStartGame?.onClick.AddListener(EnableStartGame);
        _buttonEnablePauseGame?.onClick.AddListener(EnablePauseGame);
    }

    private void OnDisable()
    {
        _buttonEnableStartGame?.onClick.RemoveListener(EnableStartGame);
        _buttonEnablePauseGame?.onClick.RemoveListener(EnablePauseGame);
    }

    private void EnableStartGame()
    {
        float maxValueTime = 1f;

        _canvasPauseGame.SetActive(false);
        _canvasGame.SetActive(true);
        _player.SetActive(true);

        ChangeTime(maxValueTime);
    }

    private void EnablePauseGame()
    {
        float minValueTime = 0f;

        _canvasGame.SetActive(false);
        _player.SetActive(false);
        _canvasPauseGame.SetActive(true);

        ChangeTime(minValueTime);
    }

    private void ChangeTime(float valueTime)
    {
        Time.timeScale = valueTime;
    }
}
