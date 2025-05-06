using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : ObjectController
{
    [SerializeField] Transform position;
    public Transform Position { get { return position; } }

    bool isOpen;

    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;

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


    private void OpenDoor()
    {
        beforeObject.SetActive(false);
        afterObject.SetActive(true);
        isOpen = true;
        tilemapCollider.isTrigger = true;

        //sound
        SoundManager.PlayClip(openSound);
    }

    private void CloseDoor()
    {
        afterObject.SetActive(false);
        beforeObject.SetActive(true);
        isOpen = false;
        tilemapCollider.isTrigger = false;

        //sound
        SoundManager.PlayClip(closeSound);
    }

    public void ForeDoorPlayer()
    {
        beforeRenderer.sortingOrder = 10;
        afterRenderer.sortingOrder = 10;
    }

    public void BackDoorPlayer()
    {
        beforeRenderer.sortingOrder = 120;
        afterRenderer.sortingOrder = 120;
    }

}
