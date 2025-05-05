using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class ObjectController : MonoBehaviour
{
    protected TilemapRenderer beforeRenderer;   //Ȱ��ȭ ��
    protected TilemapRenderer afterRenderer;    //Ȱ��ȭ ��
    [SerializeField] protected GameObject afterObject;
    [SerializeField] protected GameObject beforeObject;
    protected TilemapCollider2D tilemapCollider;    //�浹 ����

    public bool IsActive;   //������Ʈ �۵�����

    protected Material defaultMaterial; //���� ���׸���

    [SerializeField] Material outLineMaterial;  //Ȱ��ȭ ���� �� ���׸���
    protected Material OutLineMaterial { get { return outLineMaterial; } }

    protected void Awake()
    {
        beforeRenderer = beforeObject.GetComponent<TilemapRenderer>();
        afterRenderer = afterObject.GetComponent<TilemapRenderer>();

        defaultMaterial = beforeRenderer.material;

        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    protected void Update()
    {
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

    public abstract void ActiveObject();

}
