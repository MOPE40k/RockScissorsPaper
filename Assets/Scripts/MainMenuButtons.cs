using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
