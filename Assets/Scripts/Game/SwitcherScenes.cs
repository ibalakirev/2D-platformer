using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitcherScenes : MonoBehaviour
{
    private const string Level1 = nameof(Level1);
    private const string MainMenu = nameof(MainMenu);

    public void OpenGame()
    {
        float maxValueTime = 1f;

        SceneManager.LoadScene(Level1);

        Time.timeScale = maxValueTime;
    }

    public void OpenMainMeu()
    {
        float maxValueTime = 1f;

        Time.timeScale = maxValueTime;

        SceneManager.LoadScene(MainMenu);
    }
}
