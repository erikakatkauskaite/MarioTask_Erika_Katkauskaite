using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    private int startTimeSeconds =400;

    private float currentTime = 0;
    private int score = 0;
    private int coins = 0;
    public int currentLevelIndex = 0;
    

    private int goombaKillSpreeCounter = 0;
    private float goombaLastKillTimer = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI worldText;
    public TextMeshProUGUI nextLevelInd;

    void Awake()
    {
        scoreText.text = "MARIO\n" + score.ToString();
        coinsText.text = "\nx " + coins.ToString();
        timeText.text = "TIME\n" + Convert.ToInt32(currentTime).ToString();
        worldText.text = "WORLD\n" + "1 - " + (currentLevelIndex + 1).ToString();
        nextLevelInd.text = "WORLD   " + "1 - " +(currentLevelIndex + 1).ToString();
        currentTime = startTimeSeconds;
    }

    void Update()
    {
        scoreText.text = "MARIO\n" + score.ToString();
        coinsText.text = "\nx " + coins.ToString();
        timeText.text = "TIME\n" + Convert.ToInt32( currentTime).ToString();
        if (!FindObjectOfType<Win>().gameHasEnded)
        {
            currentTime = currentTime - Time.deltaTime;
        }
        
        goombaLastKillTimer = goombaLastKillTimer + Time.deltaTime;
        
        //if (score > 2000)
        //{
        //    UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.AccessViolation);
        //}

        //RESTART
        if (currentTime <= 0)
        {
            FindObjectOfType<GameManager>().RestartTheGame();
        }
			

    }
    ////GETS///////////////////////
    public float GetCurrentTime()
    {
        return currentTime;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    ////OTHER METHODS///////////////
    public void Goomba()
    {
        if (goombaLastKillTimer > 0.5f) //If Goomba was killed more than 0.5 seconds ago, we don't care about it
            goombaKillSpreeCounter = 0;
		
        score += (100 * (2 * goombaKillSpreeCounter)); //More killing, more score

        if (goombaKillSpreeCounter == 0) //Score that we add if no Goomba was killed in the last 0.5 seconds
            score += 100;

        goombaKillSpreeCounter++;
        goombaLastKillTimer = 0f;
    }

    public void Mushroom()
    {
        score += 1000;
    }

    public void Coin()
    {
        score += 200;
        coins++;
    }

    public void Brick()
    {
        score += 50;
    }
}
