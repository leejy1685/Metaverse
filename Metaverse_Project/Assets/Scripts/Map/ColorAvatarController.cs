using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAvatarController : ObjectController
{
    //�ƹ�Ÿ�� ������ �ִ� ����
    private SpriteRenderer nonTileRenderer;

    protected void Awake()
    {   //Ÿ�ϸ��� �ƴ϶� ���� �ڵ�
        nonTileRenderer = GetComponent<SpriteRenderer>();

        defaultMaterial = nonTileRenderer.material;
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

    //UI ����
    public override void ActiveObject()
    {
        GameManager.instance.ColorCustumStart();
    }
}
