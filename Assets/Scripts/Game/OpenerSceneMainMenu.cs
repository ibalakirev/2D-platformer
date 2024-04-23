using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenerSceneMainMenu : SwitcherScenes
{
    private const string MainMenu = nameof(MainMenu);

    protected override void OpenScene()
    {
        float maxValueTime = 1f;

        Time.timeScale = maxValueTime;

        SceneManager.LoadScene(MainMenu);
    }
}
