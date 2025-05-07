using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ UI ���¸� �����ϴ� ������
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
    private UIState currentState;// ���� UI ����

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // �ڽ� ������Ʈ���� ������ UI�� ã�� �ʱ�ȭ
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

        // �ʱ� ���¸� Ȩ ȭ������ ����
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
    // ���� UI ���¸� �����ϰ�, �� UI ������Ʈ�� ���¸� ����
    public void ChangeState(UIState state)
    {
        currentState = state;

        // �� UI�� �ڽ��� �������� �� �������� �Ǵ��ϰ� ǥ�� ���� ����
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

