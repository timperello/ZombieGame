using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/Map");
        Cursor.visible = false;
    }
    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("Scenes/CreditsMenu");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
