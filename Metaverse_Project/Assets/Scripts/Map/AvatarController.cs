using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : ObjectController
{
    //�ƹ�Ÿ�� ������ �ִ� ����
    private SpriteRenderer nonTileRenderer;
    [SerializeField] AnimationClip[] animationClips;

    //�ʿ��� �÷��̾��� ����
    SpriteRenderer playerSprite;
    AnimationHandler animationHandler;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        if (collision.CompareTag("Player"))
        {   //�÷��̾��� ��������Ʈ�� �ִϸ��̼� ��������
            playerSprite = collision.GetComponentInChildren<SpriteRenderer>();
            animationHandler = collision.GetComponent<AnimationHandler>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base .OnTriggerExit2D (collision);
        if (collision.CompareTag("Player"))
        {   //Ż�� �� ����
            playerSprite = null;
            animationHandler = null;
        }
    }

    public override void ActiveObject()
    {
        //��������Ʈ�� �ִϸ��̼� ����
        playerSprite.sprite = nonTileRenderer.sprite;
        animationHandler.ChangeAnimation(animationClips);
    }
}
