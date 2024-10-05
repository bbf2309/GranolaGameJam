using UnityEngine;
using UnityEngine.SceneManagement; //switch between scenes

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Goes to a scene
    /// </summary>
    /// <param name="sceneName">the scene your going to</param>
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Quits Game 
    /// </summary>
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}