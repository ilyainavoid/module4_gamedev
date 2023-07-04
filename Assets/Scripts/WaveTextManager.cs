using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTextManager : MonoBehaviour
{
    public Text wave;
    void Start()
    {
        SetWaveText(1);
    }

    public void SetWaveText(int currentWave)
    {
        wave.text = "Current wave: " + currentWave + "/5";
    }
}
