using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomController : MonoBehaviour
{
    //방의 범위
    [SerializeField] private Rect room; 
    public Rect Room { get { return room; } }

    //방의 충돌
    [SerializeField] private GameObject roomCollider;
    //방의 앞 디자인과 뒤 디자인
    [SerializeField] private TilemapRenderer backDesign;
    [SerializeField] private TilemapRenderer foreDesign;

    //방의 범위 설정(기즈모 이용)
    private void OnDrawGizmosSelected()
    {
        if (room == null) return;

        Gizmos.color = new Color(1, 0, 0, 0.2f);

        Vector3 center = new Vector3(room.x + room.width / 2, room.y + room.height / 2);
        Vector3 size = new Vector3(room.width, room.height);
        Gizmos.DrawCube(center, size);
    }

    //방 안에 있을 때 OrderInLayer 조정
    public void InRoom()
    {
        roomCollider.SetActive(true);
        backDesign.sortingOrder = 10;
        foreDesign.sortingOrder = 120;

    }

    //방 밖에 있을 때 OrderInLayer 조정
    public void OutRoom()
    {
        roomCollider.SetActive(false);
        backDesign.sortingOrder = 10;
        foreDesign.sortingOrder = 10;
    }

    //방의 좌표를 계산하기 편하게 하기 위해서 이런식으로 리턴
    public Vector2 mapMinValue()
    {
        return new Vector2(room.x, room.y);
    }
    public Vector2 mapMaxValue()
    {
        return new Vector2(room.x + room.width, room.y + room.height);
    }

}
