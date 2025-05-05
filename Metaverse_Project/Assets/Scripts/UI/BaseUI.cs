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

    // ���� UI ����(UIState) ���� (�ڽ� Ŭ�������� �����ؾ� ��)
    protected abstract UIState GetUIState();

    // ���޵� ���¿� ���� UI�� ���°� ��ġ�ϸ� Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
