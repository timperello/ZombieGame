using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject Map_v1;
    public GameObject pauseMenu;
    public static bool enPause;
    public CursorLockMode desiredMode;
    public GameObject player;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsC;
    //public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        fpsC = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(enPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //audio.mute = true;
        enPause = true;
        desiredMode = CursorLockMode.None;
        Cursor.lockState = desiredMode;
        
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        enPause = false;
        desiredMode = CursorLockMode.Confined;
        fpsC.isPaused = !fpsC.isPaused;
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Menu");
    }
    public void Quitter()
    {
        Application.Quit();
    }
}
