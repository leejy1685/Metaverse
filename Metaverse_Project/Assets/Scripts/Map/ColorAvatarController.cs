using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAvatarController : ObjectController
{
    //�ƹ�Ÿ�� ������ �ִ� ����
    private SpriteRenderer nonTileRenderer;

    GameManager gameManager;

    protected void Awake()
    {   //Ÿ�ϸ��� �ƴ϶� ���� �ڵ�
        nonTileRenderer = GetComponent<SpriteRenderer>();

        defaultMaterial = nonTileRenderer.material;
    }
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    protected void Update()
    {
        //�ܰ���
        if (IsActive)
        {
            nonTileRenderer.material = OutLineMaterial;
        }
        else
        {
            nonTileRenderer.material = defaultMaterial;
        }
    }

    public override void ActiveObject()
    {
        gameManager.ColorCustumStart();
    }
}
