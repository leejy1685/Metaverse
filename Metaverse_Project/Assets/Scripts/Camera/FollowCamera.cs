using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    private BaseController baseController;

    private GameManager gameManager;
    private MapManager mapManager;

    void Start()
    {
        baseController = target.GetComponent<BaseController>();
        gameManager = GameManager.instance;
        mapManager = MapManager.instance;

    }

    void FixedUpdate()
    {
        Vector3 pos;
        if (gameManager.JumpGamePlayed)
        {   //점프 게임 중 카메라 위치
            pos = transform.position;
            pos.x = mapManager.JumpGameCameraPostion.position.x;
            pos.y = mapManager.JumpGameCameraPostion.position.y;
            transform.position = pos;
            return;
        }

        pos = transform.position;
        pos.x = target.position.x;
        if(!baseController.IsJump)
            pos.y = target.position.y;
        transform.position = pos;
    }

}
