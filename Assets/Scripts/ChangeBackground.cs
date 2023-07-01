using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBackground : MonoBehaviour
{
    public GameObject firstPart;
    public GameObject secondPart;
    public GameObject thirdPart;
    int currentPart = 0;
    void Start()
    {
        firstPart.SetActive(true);
        secondPart.SetActive(false);
        thirdPart.SetActive(false);
        currentPart++;
    }

    void Update()
    {
        
    }

    public void BackgroundChanger()
    {
        if (currentPart == 1)
        {
            firstPart.SetActive(false);
            secondPart.SetActive(true);
            thirdPart.SetActive(false);
            currentPart++;
        }
        else if (currentPart == 2)
        {
            firstPart.SetActive(false);
            secondPart.SetActive(false);
            thirdPart.SetActive(true);
            currentPart++;
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
