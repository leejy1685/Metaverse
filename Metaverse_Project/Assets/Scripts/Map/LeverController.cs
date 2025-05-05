using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LeverController : ObjectController
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public override void ActiveObject()
    {
        //게임 시작
        RightLever();
        gameManager.JumpGameStart();
    }

    public void RightLever()
    {
        beforeObject.SetActive(false);
        afterObject.SetActive(true);
    }

    public void LeftLever()
    {
        beforeObject.SetActive(true);
        afterObject.SetActive(false);
    }
}
