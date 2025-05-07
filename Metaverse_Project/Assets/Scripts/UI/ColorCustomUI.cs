using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCustomUI : BaseUI
{
    //UI
    [SerializeField] Image CharacterImage;
    [SerializeField] Slider Red;
    [SerializeField] Slider Green;
    [SerializeField] Slider Blue;
    [SerializeField] Button OkButton;

    //플레이어 정보
    [SerializeField] SpriteRenderer playerSprtie;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        //현재 캐릭터의 rgb값을 슬라이더에 넣기
        Red.value = playerSprtie.color.r;
        Green.value = playerSprtie.color.g;
        Blue.value = playerSprtie.color.b;

        //캐릭터 이미지 보여주기
        CharacterImage.sprite = playerSprtie.sprite;

        //ok 버튼 기능 넣어주기
        OkButton.onClick.AddListener(ChangeColor);
    }

    protected override UIState GetUIState()
    {
        return UIState.ColorCustom;
    }

    private void Update()
    {
        UpdateImage();  //이미지 업데이트
    }

    //색이 변화함에 따라 이미지 변경
    public void UpdateImage()
    {   
        CharacterImage.sprite = playerSprtie.sprite;
        Color newColor = new Color(Red.value, Green.value, Blue.value);
        CharacterImage.color = newColor;
    }

    //변경된 색으로 캐릭터에 적용
    public void ChangeColor()
    {
        Color newColor = new Color(Red.value, Green.value, Blue.value);
        playerSprtie.color = newColor;
        uiManager.ChangeState(UIState.Game);
    }

}
