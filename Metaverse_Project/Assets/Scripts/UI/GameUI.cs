using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] TextMeshProUGUI JumpGamePoint;

    [SerializeField] Button ExitButton;
    public override void Init(UIManager uIManager)
    {  
        base.Init(uiManager);// BaseUI���� UIManager ����

        //�ְ� ���� ������Ʈ
        UpdateBestScore();

        // ��ư Ŭ�� �̺�Ʈ ����
        ExitButton.onClick.AddListener(OnClickExitButton);

    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public void OnClickExitButton()
    {
        Application.Quit();//���� ����
    }

    public void UpdateBestScore()
    {
        //Ű �� ��������
        string BestScoreString = gameManager.JumpGameBestScore;
        //���� �ְ� ���� ǥ��
        float bestScore = PlayerPrefs.GetInt(BestScoreString, 0);
        JumpGamePoint.text = bestScore.ToString();
    }

}
