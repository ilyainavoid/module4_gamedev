using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuLogic : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused =false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
            {
                ResumeGame();
            }
            if (!isPaused)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
