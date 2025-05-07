using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임의 UI 상태를 정의하는 열거형
public enum UIState
{
    Home,
    Game,
    JumpGame,
    JumpGameOver,
    ColorCustom
}
public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    GameUI gameUI;
    JumpGameUI jumpGameUI;
    JumpGameOverUI jumpGameOverUI;
    ColorCustomUI colorCustomUI;
    private UIState currentState;// 현재 UI 상태

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // 자식 오브젝트에서 각각의 UI를 찾아 초기화
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        jumpGameUI = GetComponentInChildren<JumpGameUI>(true);
        jumpGameUI.Init(this);
        jumpGameOverUI = GetComponentInChildren<JumpGameOverUI>(true);
        jumpGameOverUI.Init(this);
        colorCustomUI = GetComponentInChildren<ColorCustomUI>(true);
        colorCustomUI.Init(this);

        // 초기 상태를 홈 화면으로 설정
        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetJumpGame()
    {
        ChangeState(UIState.JumpGame);
    }

    public void SetJumpGameOver()
    {
        ChangeState(UIState.JumpGameOver);
    }

    public void SetColorCustomUI()
    {
        ChangeState(UIState.ColorCustom);
    }
    // 현재 UI 상태를 변경하고, 각 UI 오브젝트에 상태를 전달
    public void ChangeState(UIState state)
    {
        currentState = state;

        // 각 UI가 자신이 보여져야 할 상태인지 판단하고 표시 여부 결정
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        jumpGameUI.SetActive(currentState);
        jumpGameOverUI.SetActive(currentState);
        colorCustomUI.SetActive(currentState);
    }

    public void ChangeScore(int score)
    {
        jumpGameUI.UdpateScore(score);
    }

    public void ChangeGamePanel()
    {
        jumpGameOverUI.UpdatePanel();
        gameUI.UpdateBestScore();
    }

}

