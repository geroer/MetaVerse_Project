using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    public TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score)
    {
        scoreText.text = score.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
