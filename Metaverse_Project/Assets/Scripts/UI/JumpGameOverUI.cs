using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameOverUI : BaseUI
{
    //최고 점수와 현재 점수 Text
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI Score;

    //재시작 버튼
    [SerializeField] Button retryButton;
    //확인 버튼
    [SerializeField] Button CheckButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        //판넬 업데이트
        UpdatePanel();

        //버튼 기능 연결
        retryButton.onClick.AddListener(retryGame);
        CheckButton.onClick.AddListener(CheckGame);

    }
    protected override UIState GetUIState()
    {
        return UIState.JumpGameOver;
    }

    //재시작 버튼
    private void retryGame()
    {   
        gameManager.JumpGameStart();
    } 

    //확인 버튼
    private void CheckGame()
    {   
        uiManager.ChangeState(UIState.Game);
    }

    //업데이트 판넬
    public void UpdatePanel()
    {
        //점수 가져오기
        string BestScoreString = gameManager.JumpGameBestScore;
        int bestscore = PlayerPrefs.GetInt(BestScoreString, 0);
        int score = gameManager.JumpGameScore;

        //점수 표시
        bestScore.text = bestscore.ToString();
        Score.text = score.ToString();
    }
}
