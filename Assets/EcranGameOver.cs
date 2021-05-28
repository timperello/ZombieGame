using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EcranGameOver : MonoBehaviour
{
    
    public void Setup (int score)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    public void Recommencer()
    {
        SceneManager.LoadScene("Scenes/Map");
        Time.timeScale = 1f;
    }
    public void Quitter()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
