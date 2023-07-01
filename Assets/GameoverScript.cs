using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour
{
    public GameObject HUD;
    public void Setup()
    {
        HUD.SetActive(false);
        gameObject.SetActive(true);
    }

    public void RestartButtonScript()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
