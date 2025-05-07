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
        base.Init(uiManager);// BaseUI에서 UIManager 저장

        //최고 점수 업데이트
        UpdateBestScore();

        // 버튼 클릭 이벤트 연결
        ExitButton.onClick.AddListener(OnClickExitButton);

    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public void OnClickExitButton()
    {
        Application.Quit();//게임 종료
    }

    public void UpdateBestScore()
    {
        //키 값 가져오기
        string BestScoreString = gameManager.JumpGameBestScore;
        //게임 최고 점수 표시
        float bestScore = PlayerPrefs.GetInt(BestScoreString, 0);
        JumpGamePoint.text = bestScore.ToString();
    }

}
