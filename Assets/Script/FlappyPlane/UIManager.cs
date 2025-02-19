using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Home,
    Game,
    GameOver,
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public static UIManager Instance {  get { return instance; } }

    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        Time.timeScale = 1;
        ChangeState(UIState.Game);
    }

    public void SetGameOver(int score, int bestScore)
    {
        Time.timeScale = 0;
        gameOverUI.SetUI(score, bestScore);
        ChangeState(UIState.GameOver);
    }

    public void UpdateScore(int score)
    {
        gameUI.SetUI(score);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }
}
