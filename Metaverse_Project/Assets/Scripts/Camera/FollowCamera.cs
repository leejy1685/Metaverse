using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FollowCamera : MonoBehaviour
{
    //캐릭터의 정보
    [SerializeField] Transform target;
    private BaseController baseController;

    //매니저 클래스 추가
    private GameManager gameManager;
    private MapManager mapManager;

    
    private float height;   //카메라가 비추는 높이(좌표값)
    private float width;    //카메라가 비추는 폭(좌표값)

    void Start()
    {
        //필요한 데이터 가져오기
        baseController = target.GetComponent<BaseController>();
        gameManager = GameManager.instance;
        mapManager = MapManager.instance;

        //높이와 폭 계산
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        JumpGameCamera();   //점프 게임 시 카메라 위치
        DefalutCamera();    //평소의 카메라 위치
    }

    //점프 게임 시 카메라 위치
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
        //게임중에는 작동하지 않음
        if (gameManager.JumpGamePlayed)
            return;

        //현재 위치 전달
        Vector3 pos;
        pos = transform.position;

        //캐릭터 위치 가져오기
        pos.x = target.position.x;
        if (!baseController.IsJump) //점프 중에는 y 좌표 변환 없음
            pos.y = target.position.y;

        //카메라 맵 밖에 안나가게 범위 제한
        pos.x = Mathf.Clamp(pos.x, mapManager.MapSizeMin.x + width, mapManager.MapSizeMax.x - width);
        pos.y = Mathf.Clamp(pos.y, mapManager.MapSizeMin.y + height,mapManager.MapSizeMax.y - height);

        //카메라 좌표 넣어주기
        transform.position = pos;
    }

}
