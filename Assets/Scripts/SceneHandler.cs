using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public void SceneLoad(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }
}
