using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LeverController : ObjectController
{
    //게임 실행에 필요한 매니저
    GameManager gameManager;

    //레버 사운드
    [SerializeField] AudioClip LeverSound;

    private void Start()
    {   //정보 가져오기
        gameManager = GameManager.instance;
    }

    public override void ActiveObject()
    {
        //게임 시작
        RightLever();
        gameManager.JumpGameStart();
    }

    //레버가 오른쪽으로
    public void RightLever()
    {
        //sound
        SoundManager.PlayClip( LeverSound );

        beforeObject.SetActive(false);
        afterObject.SetActive(true);
    }

    //레버가 왼쪽으로
    public void LeftLever()
    {
        //sound
        SoundManager.PlayClip(LeverSound);

        beforeObject.SetActive(true);
        afterObject.SetActive(false);
    }
}
