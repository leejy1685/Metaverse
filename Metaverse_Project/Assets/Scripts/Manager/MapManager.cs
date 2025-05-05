using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField] private Transform player;

    private RoomController[] rooms;
    private DoorController[] dooms;

    [SerializeField] private Transform jumpGamePosition;
    public Transform JumpGamePosition {  get { return jumpGamePosition; }}
    [SerializeField] private Transform jumpGameCameraPosition;
    public Transform JumpGameCameraPostion { get { return jumpGameCameraPosition; } }


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rooms = GetComponentsInChildren<RoomController>();
        dooms = GetComponentsInChildren<DoorController>();
    }

    private void Update()
    {
        foreach (RoomController room in rooms)
        {
            if (room.Room.Contains(player.position))
            {
                room.InRoom();
            }
            else
            {

                room.OutRoom();
            }
        }

        foreach(DoorController door in dooms)
        {
            if(door.Position.position.y > player.position.y)
            {
                door.ForeDoorPlayer();
            }
            else
            {
                door.BackDoorPlayer();
            }
        }
    }

}
