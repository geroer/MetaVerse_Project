using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    private int bestScore = 0;
    public static bool isFirstLoading = true;

    private const string BestScoreKey = "BestScore";

    UIManager uiManager;

    public UIManager UIMaster { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);

        Time.timeScale = 0;

        if (!isFirstLoading)
        {
            StartGame();
            uiManager.UpdateScore(0);
        }
        else
        {
            isFirstLoading = false;
        }
    }
    
    public void StartGame()
    {
        uiManager.SetPlayGame();
    }

    public void GameOver()
    {
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
        uiManager.SetGameOver(currentScore, bestScore);
    }

    public void AddScroe(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }

}
