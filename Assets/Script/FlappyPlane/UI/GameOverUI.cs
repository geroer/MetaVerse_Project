using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    TextMeshProUGUI scoreText;
    TextMeshProUGUI bestScoreText;

    int curScore;
    int bestScore;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickExitButton()
    {
        GameManager.isFirstLoading = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void SetUI(int score, int bestScore)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
