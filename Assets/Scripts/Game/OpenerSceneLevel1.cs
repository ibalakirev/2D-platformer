using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenerSceneLevel1 : SwitcherScenes
{
    private const string Level1 = nameof(Level1);

    protected override void OpenScene()
    {
        float maxValueTime = 1f;

        Time.timeScale = maxValueTime;

        SceneManager.LoadScene(Level1);
    }
}
