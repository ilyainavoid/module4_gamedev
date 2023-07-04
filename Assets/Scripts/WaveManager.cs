using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Spawner spawner;
    
    public int score;
    public int currentWave;
    public WaveTextManager textManager;
    private void Start()
    {
        currentWave = 1;
        
    }

    void Update()
    {
        score = scoreManager.score;
        if (score > 1 && score < 2)
        {
            currentWave = 2;
        }
        if (score >= 2 && score <3)
        {
            currentWave = 3;

        }
        if(score >= 3 && score < 4){
            currentWave = 4;
        }

        if (score >= 4)
        {
            if (!spawner.bossSpawned)
            {
                spawner.spawnBoss = true;
                currentWave = 5;
            }
        }
        textManager.SetWaveText(currentWave);

    }
}
