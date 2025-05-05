using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    protected GameManager gameManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
        gameManager = GameManager.instance;
    }

    // 현재 UI 상태(UIState) 정의 (자식 클래스에서 구현해야 함)
    protected abstract UIState GetUIState();

    // 전달된 상태와 현재 UI의 상태가 일치하면 활성화, 아니면 비활성화
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
