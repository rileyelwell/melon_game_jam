using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Start()
    {
        // ensure the game is not paused at the start
        Resume(); 
    }

    void Update()
    {
        // toggle pause/resume when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
    
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show pause menu UI
        Time.timeScale = 0f; // Stop time
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide pause menu UI
        Time.timeScale = 1f; // Resume time
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit(); // quit the application

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // stop play mode in the editor
        #endif
    }
}
