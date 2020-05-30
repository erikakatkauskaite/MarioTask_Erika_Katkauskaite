using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject WinUI;
    private int nextLevelIndex;
    private bool gameEnded;



    private void Start()
    {
        gameEnded = FindObjectOfType<Win>().gameHasEnded;
        WinUI.SetActive(false);
        //nextLevelIndex = FindObjectOfType<ScoreManager>().currentLevelIndex +1 ;
        nextLevelIndex = FindObjectOfType<ScoreManager>().currentLevelIndex;
    }

    private void Update()
    {
        gameEnded = FindObjectOfType<Win>().gameHasEnded;
        if (gameEnded)
        {
            Invoke("ShowWinUI", 9);
            Invoke("NextLevel", 13);
        }
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ShowWinUI()
    {
        WinUI.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }
}
