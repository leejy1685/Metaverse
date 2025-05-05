using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameOverUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI Score;

    [SerializeField] Button retryButton;
    [SerializeField] Button CheckButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        UpdatePanel();

        //��ư ��� ����
        retryButton.onClick.AddListener(retryGame);
        CheckButton.onClick.AddListener(CheckGame);

    }
    protected override UIState GetUIState()
    {
        return UIState.JumpGameOver;
    }

    private void retryGame()
    {
        gameManager.JumpGameStart();
    } 

    private void CheckGame()
    {
        uiManager.ChangeState(UIState.Game);
    }

    public void UpdatePanel()
    {
        //���� ��������
        string BestScoreString = gameManager.JumpGameBestScore;
        int bestscore = PlayerPrefs.GetInt(BestScoreString, 0);
        int score = gameManager.JumpGameScore;

        //���� ǥ��
        bestScore.text = bestscore.ToString();
        Score.text = score.ToString();
    }
}
