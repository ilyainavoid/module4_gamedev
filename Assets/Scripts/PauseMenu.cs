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
    public Button quitButton; // ������ �� ������ Quit
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

        // ����������� ��������
        foreach (MonoBehaviour component in componentsToPause)
        {
            component.enabled = true;
        }
    }

    void Pause()
    {
        quitButton.GetComponentInChildren<Text>().text = "����";
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // ������������� ��������
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
