using UnityEngine;
using UnityEngine.UI;

public class SwitcherTimeGame : MonoBehaviour
{
    [SerializeField] private Canvas _canvasGame;
    [SerializeField] private Canvas _canvasPauseGame;
    [SerializeField] private Health _player;
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

        _canvasPauseGame.gameObject.SetActive(false);
        _canvasGame.gameObject.SetActive(true);
        _player.gameObject.SetActive(true);

        ChangeTime(maxValueTime);
    }

    private void EnablePauseGame()
    {
        float minValueTime = 0f;

        _canvasGame.gameObject.SetActive(false);
        _player.gameObject.SetActive(false);
        _canvasPauseGame.gameObject.SetActive(true);

        ChangeTime(minValueTime);
    }

    private void ChangeTime(float valueTime)
    {
        Time.timeScale = valueTime;
    }
}
