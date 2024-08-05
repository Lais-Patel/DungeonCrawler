using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Menus : MonoBehaviour
{
    public GameObject PauseMenu;                // Reference to the Pause Menu game object
    public GameObject SettingsMenu;             // Reference to the Settings Menu game object
    public GameObject AudioMenu;                // Reference to the Audio Menu Panel game object
    public GameObject GraphicsMenu;             // Reference to the Graphics Menu Panel game object
    public GameObject DifficultyMenu;           // Reference to the Difficulty Menu Panel game object
    public GameObject GameOverScreen;           // Reference to the GameOver Screen game object
	[SerializeField] private GameOver GameOver; // Reference to the GameOver Script
    public static float difficultyRating;       // Stores the difficulty of the game
    public static bool isGamePaused;            // If the game is currently in a paused state

    // Start is called before the first frame update
    void Start()
    {   // Checks if Difficulty Rating exists and collects the value, else sets a default value
        if (PlayerPrefs.HasKey("DifficultyRating"))
        {
            difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
        }
        else
        {
            difficultyRating = 2f;
        }
        
        // Ensures all the different panels are deactivated upon start
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        AudioMenu.SetActive(false);
        GraphicsMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
        GameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {   // Toggle pause with the escape key
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
        Time.timeScale = 1f;
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
        PauseMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    
    public void OpenSettingsMenu()
    {
        SettingsMenu.SetActive(true);
        PauseMenu.SetActive(false);
        AudioMenu.SetActive(false);
        GraphicsMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
    }
    
    public void CloseSettingsMenu()
    {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
        AudioMenu.SetActive(false);
        GraphicsMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
    }
    
    public void OpenAudioMenu()
    {
        AudioMenu.SetActive(true);
        GraphicsMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
    }

    public void OpenGraphicsMenu()
    {
        AudioMenu.SetActive(false);
        GraphicsMenu.SetActive(true);
        DifficultyMenu.SetActive(false);
    }
    
    public void OpenDifficultyMenu()
    {
        AudioMenu.SetActive(false);
        GraphicsMenu.SetActive(false);
        DifficultyMenu.SetActive(true);
    }
    
    // Activates the gameover screen and pauses the games process
	public void EndGame()
	{
		GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
		isGamePaused = true;
		GameOver.UpdateScoreScreen();
	}
    public void QuitGame()
    {
        Application.Quit();
    }
}
