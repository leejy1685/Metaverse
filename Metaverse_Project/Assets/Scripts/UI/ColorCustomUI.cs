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

    //�÷��̾� ����
    [SerializeField] SpriteRenderer playerSprtie;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        //���� ĳ������ rgb���� �����̴��� �ֱ�
        Red.value = playerSprtie.color.r;
        Green.value = playerSprtie.color.g;
        Blue.value = playerSprtie.color.b;

        //ĳ���� �̹��� �����ֱ�
        CharacterImage.sprite = playerSprtie.sprite;

        //ok ��ư ��� �־��ֱ�
        OkButton.onClick.AddListener(ChangeColor);
    }

    protected override UIState GetUIState()
    {
        return UIState.ColorCustom;
    }

    private void Update()
    {
        UpdateImage();  //�̹��� ������Ʈ
    }

    //���� ��ȭ�Կ� ���� �̹��� ����
    public void UpdateImage()
    {   
        CharacterImage.sprite = playerSprtie.sprite;
        Color newColor = new Color(Red.value, Green.value, Blue.value);
        CharacterImage.color = newColor;
    }

    //����� ������ ĳ���Ϳ� ����
    public void ChangeColor()
    {
        Color newColor = new Color(Red.value, Green.value, Blue.value);
        playerSprtie.color = newColor;
        uiManager.ChangeState(UIState.Game);
    }

}
