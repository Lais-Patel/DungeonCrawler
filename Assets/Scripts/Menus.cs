using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;                // Reference to the Pause Menu game object
    public GameObject settingsMenu;             // Reference to the Settings Menu game object
    public GameObject audioMenu;                // Reference to the Audio Menu Panel game object
    public GameObject graphicsMenu;             // Reference to the Graphics Menu Panel game object
    public GameObject difficultyMenu;           // Reference to the Difficulty Menu Panel game object
    public GameObject gameOverScreen;           // Reference to the GameOver Screen game object
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
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
        gameOverScreen.SetActive(false);
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
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    
    public void openSettingsMenu()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
    }
    
    public void closeSettingsMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
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
    
    // Activates the gameover screen and pauses the games process
	public void endGame()
	{
		gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
		isGamePaused = true;
		GameOver.updateScoreScreen();
	}
    public void QuitGame()
    {
        Application.Quit();
    }
}
