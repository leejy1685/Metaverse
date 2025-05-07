using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAvatarController : ObjectController
{
    //아바타가 가지고 있는 정보
    private SpriteRenderer nonTileRenderer;

    GameManager gameManager;

    protected void Awake()
    {   //타일맵이 아니라서 새로 코딩
        nonTileRenderer = GetComponent<SpriteRenderer>();

        defaultMaterial = nonTileRenderer.material;
    }
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    protected void Update()
    {
        //외곽선
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
