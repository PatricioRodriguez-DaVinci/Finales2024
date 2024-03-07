using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(MyScene sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Closed");
    }
}

public enum MyScene
{
    Level_1,
    Win,
    GameOver,
    MainMenu
}