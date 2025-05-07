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
        {   //���� ���� �� ī�޶� ��ġ
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
        //��ġ ���
        pos.x = target.position.x;
        if (!baseController.IsJump) //���� �߿��� y ��ǥ ��ȯ ����
            pos.y = target.position.y;


        //ī�޶� �� �ۿ� �ȳ����� ����
        pos.x = Mathf.Clamp(pos.x, mapManager.MapSizeMin.x + width, mapManager.MapSizeMax.x - width);
        pos.y = Mathf.Clamp(pos.y, mapManager.MapSizeMin.y + height,mapManager.MapSizeMax.y - height);

        transform.position = pos;
    }

}
