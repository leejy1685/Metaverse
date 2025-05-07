using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    //싱글톤
    public static MapManager instance;  

    //플레이어 정보
    [SerializeField] private Transform player;

    //방과 문
    private RoomController[] rooms;
    private DoorController[] dooms;

    //점프 게임 구현
    [SerializeField] private Transform jumpGamePosition;

    //점프 게임
    public Transform JumpGamePosition { get { return jumpGamePosition; } }
    [SerializeField] private Transform jumpGameCameraPosition;
    public Transform JumpGameCameraPostion { get { return jumpGameCameraPosition; } }

    [SerializeField] private Transform arrowSpwanPostion;
    public Transform ArrowSpwanPostion { get { return arrowSpwanPostion; } }

    //카메라가 필요한 맵의 정보
    private Vector2 mapSizeMin;
    public Vector2 MapSizeMin { get { return mapSizeMin; } }

    private Vector2 mapSizeMax;
    public Vector2 MapSizeMax { get { return mapSizeMax; } }


    private void Awake()
    {   //싱글톤 할당
        instance = this;
    }

    private void Start()
    {   
        //방과 문을 가져오기
        rooms = GetComponentsInChildren<RoomController>();
        dooms = GetComponentsInChildren<DoorController>();

        //카메라를 위한 맵 크기 계산
        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;
        foreach (RoomController room in rooms)
        {
            if (room.mapMinValue().x < minX)
                minX = room.mapMinValue().x;
            if (room.mapMinValue().y < minY)
                minY = room.mapMinValue().y;
            if(room.mapMaxValue().x > maxX)
                maxX = room.mapMaxValue().x;
            if(room.mapMaxValue().y > maxY)
                maxY = room.mapMaxValue().y;
        }
        mapSizeMin = new Vector2(minX, minY);
        mapSizeMax = new Vector2(maxX, maxY);
        
    }

    private void Update()
    {
        //방안에 있는지 확인 OrderInLayer 조절
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

        //문 앞에 있는지 확인 OrderInLayer 조절
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
