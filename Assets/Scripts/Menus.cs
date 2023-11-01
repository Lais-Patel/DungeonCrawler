using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject audioMenu;
    public GameObject graphicsMenu;
    public GameObject difficultyMenu;

    public static float difficultyRating;
    public static bool isGamePaused;

    void Start()
    {
        if (PlayerPrefs.HasKey("DifficultyRating"))
        {
            difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
        }
        else
        {
            difficultyRating = 2f;
        }
        
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
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

    public void ChangeScenetoSettingsMenu()
    {
        SceneManager.LoadScene("MainSettingsMenu");
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
        difficultyMenu.SetActive(false);
    }

    public void openGraphicsMenu()
    {
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(true);
        difficultyMenu.SetActive(false);
    }
    
    public void openDifficultyMenu()
    {
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
