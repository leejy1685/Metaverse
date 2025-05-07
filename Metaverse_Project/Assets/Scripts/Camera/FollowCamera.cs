using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    private BaseController baseController;

    private GameManager gameManager;
    private MapManager mapManager;

    private float height;
    private float width;

    void Start()
    {
        baseController = target.GetComponent<BaseController>();
        gameManager = GameManager.instance;
        mapManager = MapManager.instance;

        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        JumpGameCamera();
        DefalutCamera();
    }

    void JumpGameCamera()
    {
        Vector3 pos;
        if (gameManager.JumpGamePlayed)
        {   //점프 게임 중 카메라 위치
            pos = transform.position;
            pos.x = mapManager.JumpGameCameraPostion.position.x;
            pos.y = mapManager.JumpGameCameraPostion.position.y;
            transform.position = pos;
        }
    }

    void DefalutCamera()
    {
        if (gameManager.JumpGamePlayed)
            return;

        Vector3 pos;
        pos = transform.position;
        //위치 계산
        pos.x = target.position.x;
        if (!baseController.IsJump) //점프 중에는 y 좌표 변환 없음
            pos.y = target.position.y;


        //카메라 맵 밖에 안나가게 제한
        pos.x = Mathf.Clamp(pos.x, mapManager.MapSizeMin.x + width, mapManager.MapSizeMax.x - width);
        pos.y = Mathf.Clamp(pos.y, mapManager.MapSizeMin.y + height,mapManager.MapSizeMax.y - height);

        transform.position = pos;
    }

}
