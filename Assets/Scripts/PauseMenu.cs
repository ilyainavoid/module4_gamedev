using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public List<MonoBehaviour> componentsToPause;
    public Button quitButton; // Ссылка на кнопку Quit
    private bool isPaused = false;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Возобновить процессы
        foreach (MonoBehaviour component in componentsToPause)
        {
            component.enabled = true;
        }
    }

    void Pause()
    {
        quitButton.GetComponentInChildren<Text>().text = "Меню";
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Приостановить процессы
        foreach (MonoBehaviour component in componentsToPause)
        {
            component.enabled = false;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
