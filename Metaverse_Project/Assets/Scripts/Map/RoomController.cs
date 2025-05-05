using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomController : MonoBehaviour
{
    [SerializeField] private Rect room;
    public Rect Room { get { return room; } }

    [SerializeField] private GameObject roomCollider;
    [SerializeField] private TilemapRenderer backDesign;
    [SerializeField] private TilemapRenderer foreDesign;

    private void OnDrawGizmosSelected()
    {
        if (room == null) return;

        Gizmos.color = new Color(1, 0, 0, 0.2f);

        Vector3 center = new Vector3(room.x + room.width / 2, room.y + room.height / 2);
        Vector3 size = new Vector3(room.width, room.height);
        Gizmos.DrawCube(center, size);
    }

    public void InRoom()
    {
        roomCollider.SetActive(true);
        backDesign.sortingOrder = 10;
        foreDesign.sortingOrder = 120;
    }

    public void OutRoom()
    {
        roomCollider.SetActive(false);
        backDesign.sortingOrder = 10;
        foreDesign.sortingOrder = 10;
    }
}
