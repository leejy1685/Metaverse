using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : ObjectController
{
    //문의 위치
    [SerializeField] Transform position;
    public Transform Position { get { return position; } }

    //문 열림 여부
    bool isOpen;

    //문 여닫이 사운드
    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;

    //문 여닫이 조절
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
        //문 열림 연출
        beforeObject.SetActive(false);
        afterObject.SetActive(true);

        //문 통과 가능
        isOpen = true;
        tilemapCollider.isTrigger = true;

        //sound
        SoundManager.PlayClip(openSound);
    }

    private void CloseDoor()
    {
        //문 닫힘 연출
        afterObject.SetActive(false);
        beforeObject.SetActive(true);

        //문 통과 불가능
        isOpen = false;
        tilemapCollider.isTrigger = false;

        //sound
        SoundManager.PlayClip(closeSound);
    }

    //문 앞에 있을 때 레이어
    public void ForeDoorPlayer()    
    {
        beforeRenderer.sortingOrder = 10;
        afterRenderer.sortingOrder = 10;
    }

    //문 뒤에 있을 때 레이어
    public void BackDoorPlayer()
    {
        beforeRenderer.sortingOrder = 120;
        afterRenderer.sortingOrder = 120;
    }

}
