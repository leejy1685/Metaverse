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
        gameManager.jumpGameStarted = true;
    }

    void RightLever()
    {
        beforeObject.SetActive(false);
        afterObject.SetActive(true);
    }

    void LeftLever()
    {
        beforeObject.SetActive(true);
        afterObject.SetActive(false);
    }
}
