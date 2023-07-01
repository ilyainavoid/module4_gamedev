using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Spawner spawner;
    
    public int score;
    public int currentWave;

    private void Start()
    {
        currentWave = 1;
    }

    void Update()
    {
        score = scoreManager.score;
        if (score > 5 )
        {
            currentWave = 2;
        }
        if (score > 10 )
        {
            currentWave = 3;
        }
        if(score > 20 )
        {
            currentWave = 4;
        }
        if(score > 25)
        {
            spawner.spawnBoss = true;
            currentWave = 5;
        }
    }
}
