using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : ObjectController
{
    TilemapRenderer openDoorRenderer;
    TilemapRenderer closeDoorRenderer;

    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closeDoor;

    bool isOpen;

    TilemapCollider2D tilemapCollider;

    private void Awake()
    {
        openDoorRenderer = openDoor.GetComponent<TilemapRenderer>();
        closeDoorRenderer = closeDoor.GetComponent<TilemapRenderer>();

        defaultMaterial = closeDoorRenderer.material;

        tilemapCollider = GetComponent<TilemapCollider2D>();
    }


    private void Update()
    {
        if (IsActive)
        {
            openDoorRenderer.material = OutLineMaterial;
            closeDoorRenderer.material = OutLineMaterial;
        }
        else
        {
            openDoorRenderer.material = defaultMaterial;
            closeDoorRenderer.material = defaultMaterial;
        }
    }

    public override void ActiveObject()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }


    public void OpenDoor()
    {
        closeDoor.SetActive(false);
        openDoor.SetActive(true);
        isOpen = true;
        tilemapCollider.isTrigger = true;
    }

    public void CloseDoor()
    {
        openDoor.SetActive(false);
        closeDoor.SetActive(true);
        isOpen = false;
        tilemapCollider.isTrigger = false;
    }

}
