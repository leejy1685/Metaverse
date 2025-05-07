using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : ObjectController
{
    //아바타가 가지고 있는 정보
    private SpriteRenderer nonTileRenderer;
    [SerializeField] AnimationClip[] animationClips;

    //필요한 플레이어의 정보
    SpriteRenderer playerSprite;
    AnimationHandler animationHandler;

    protected void Awake()
    {   //타일맵이 아니라서 새로 코딩
        nonTileRenderer = GetComponent<SpriteRenderer>();

        defaultMaterial = nonTileRenderer.material;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        if (collision.CompareTag("Player"))
        {   //플레이어의 스프라이트와 애니메이션 가져오기
            playerSprite = collision.GetComponentInChildren<SpriteRenderer>();
            animationHandler = collision.GetComponent<AnimationHandler>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base .OnTriggerExit2D (collision);
        if (collision.CompareTag("Player"))
        {   //탈출 시 제거
            playerSprite = null;
            animationHandler = null;
        }
    }

    public override void ActiveObject()
    {
        //스프라이트와 애니메이션 변경
        playerSprite.sprite = nonTileRenderer.sprite;
        animationHandler.ChangeAnimation(animationClips);
    }
}
