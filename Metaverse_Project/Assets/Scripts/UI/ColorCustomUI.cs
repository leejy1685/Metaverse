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

        Red.value = playerSprtie.color.r;
        Green.value = playerSprtie.color.g;
        Blue.value = playerSprtie.color.b;

        CharacterImage.sprite = playerSprtie.sprite;

        OkButton.onClick.AddListener(ChangeColor);
    }

    protected override UIState GetUIState()
    {
        return UIState.ColorCustom;
    }

    private void Update()
    {
        UpdateImage();
    }

    public void UpdateImage()
    {
        CharacterImage.sprite = playerSprtie.sprite;
        Color newColor = new Color(Red.value, Green.value, Blue.value);
        CharacterImage.color = newColor;
    }

    public void ChangeColor()
    {
        Color newColor = new Color(Red.value, Green.value, Blue.value);
        playerSprtie.color = newColor;
        uiManager.ChangeState(UIState.Game);
    }

}
