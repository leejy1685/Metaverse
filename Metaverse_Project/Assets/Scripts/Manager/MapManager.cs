using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] Transform player;

    //Room1
    [SerializeField] private GameObject room1TilemapCollider;
    [SerializeField] private TilemapRenderer room1Back;

    //Room2
    [SerializeField] private Rect Room;
    [SerializeField] private GameObject room2TilemapCollider;
    [SerializeField] private TilemapRenderer room2Fore;

    //Door1
    [SerializeField] private TilemapRenderer openDoor;
    [SerializeField] private TilemapRenderer closeDoor;

    // 기즈모를 그려 영역을 시각화 (선택된 경우에만 표시)
    private void OnDrawGizmosSelected()
    {
        if (Room == null) return;

        Gizmos.color = new Color(1,0,0,0.2f);

        Vector3 center = new Vector3(Room.x + Room.width / 2, Room.y + Room.height / 2);
        Vector3 size = new Vector3(Room.width, Room.height);
        Gizmos.DrawCube(center, size);

    }

    private void Update()
    {
        inRoom2();
    }

    void inRoom2()
    {
        if (Room.Contains(player.position))
        {

            room2Fore.sortingOrder = 120;
            openDoor.sortingOrder = 120;
            closeDoor.sortingOrder = 120;

            room1TilemapCollider.SetActive(false);
            room2TilemapCollider.SetActive(true);
        }
        else
        {
            room2Fore.sortingOrder = room1Back.sortingOrder;
            openDoor.sortingOrder = 10;
            closeDoor.sortingOrder = 10;

            room1TilemapCollider.SetActive(true);
            room2TilemapCollider.SetActive(false);
        }
    }

}
