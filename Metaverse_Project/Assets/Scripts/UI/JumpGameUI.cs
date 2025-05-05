using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpGameUI : BaseUI
{
    [SerializeField] TextMeshProUGUI Score;
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }

    public void UdpateScore(int score)
    {
        Score.text = score.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.JumpGame;
    }
}
