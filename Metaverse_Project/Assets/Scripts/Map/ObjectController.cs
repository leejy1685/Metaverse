using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class ObjectController : MonoBehaviour
{
    protected TilemapRenderer beforeRenderer;   //활성화 전
    protected TilemapRenderer afterRenderer;    //활성화 후
    [SerializeField] protected GameObject afterObject;
    [SerializeField] protected GameObject beforeObject;
    protected TilemapCollider2D tilemapCollider;    //충돌 여부

    public bool IsActive;   //오브젝트 작동여부

    protected Material defaultMaterial; //기존 마테리얼

    [SerializeField] Material outLineMaterial;  //활성화 가능 시 마테리얼
    protected Material OutLineMaterial { get { return outLineMaterial; } }

    protected void Awake()
    {
        //렌더러 가져오기
        beforeRenderer = beforeObject.GetComponent<TilemapRenderer>();
        afterRenderer = afterObject.GetComponent<TilemapRenderer>();

        //기존 마테리얼 저장
        defaultMaterial = beforeRenderer.material;

        //충돌여부 판단
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    protected void Update()
    {
        //활성화 가능 할 때 외곽선 생성
        if (IsActive)
        {
            beforeRenderer.material = OutLineMaterial;
            afterRenderer.material = OutLineMaterial;
        }
        else
        {
            beforeRenderer.material = defaultMaterial;
            afterRenderer.material = defaultMaterial;
        }
    }

    //플레이어와 충돌 시 활성화 가능
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = false;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = false;
        }
    }

    //오브젝트가 작동하는 추상 메서드
    public abstract void ActiveObject();

}
