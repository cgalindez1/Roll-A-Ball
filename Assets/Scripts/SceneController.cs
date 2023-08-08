using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Will change our scene to the string passed in 
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    //Reloads the current scene we are in 
    public void Reloadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //Loads out Title scene. Must be called Title exactly
    public void ToTitlescene()
    {
        SceneManager.LoadScene("Title");
    }
    //Get our active scenes name
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    // QUits our game
    public void QuitGame()
    {
        Application.Quit();
    }
}
