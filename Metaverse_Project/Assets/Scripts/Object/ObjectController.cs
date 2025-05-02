using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class ObjectController : MonoBehaviour
{
    public bool IsActive;
    protected Material defaultMaterial;
    [SerializeField] Material outLineMaterial;
    protected Material OutLineMaterial { get { return outLineMaterial; } }

    

    protected void Awake()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = true;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = false;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = false;
        }
    }

    public abstract void ActiveObject();

}
