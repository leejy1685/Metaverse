using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameOverUI : BaseUI
{
    //�ְ� ������ ���� ���� Text
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI Score;

    //����� ��ư
    [SerializeField] Button retryButton;
    //Ȯ�� ��ư
    [SerializeField] Button CheckButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        //�ǳ� ������Ʈ
        UpdatePanel();

        //��ư ��� ����
        retryButton.onClick.AddListener(retryGame);
        CheckButton.onClick.AddListener(CheckGame);

    }
    protected override UIState GetUIState()
    {
        return UIState.JumpGameOver;
    }

    //����� ��ư
    private void retryGame()
    {   
        gameManager.JumpGameStart();
    } 

    //Ȯ�� ��ư
    private void CheckGame()
    {   
        uiManager.ChangeState(UIState.Game);
    }

    //������Ʈ �ǳ�
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
