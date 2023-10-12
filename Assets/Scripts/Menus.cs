using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject audioMenu;
    public GameObject graphicsMenu;

    public static bool isGamePaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ChangeScenetoGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeScenetoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ResumeGame();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void openAudioMenu()
    {
        audioMenu.SetActive(true);
        graphicsMenu.SetActive(false);
    }

    public void openGraphicsMenu()
    {
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
