using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FollowCamera : MonoBehaviour
{
    //ĳ������ ����
    [SerializeField] Transform target;
    private BaseController baseController;

    //�Ŵ��� Ŭ���� �߰�
    private GameManager gameManager;
    private MapManager mapManager;

    
    private float height;   //ī�޶� ���ߴ� ����(��ǥ��)
    private float width;    //ī�޶� ���ߴ� ��(��ǥ��)

    void Start()
    {
        //�ʿ��� ������ ��������
        baseController = target.GetComponent<BaseController>();
        gameManager = GameManager.instance;
        mapManager = MapManager.instance;

        //���̿� �� ���
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        JumpGameCamera();   //���� ���� �� ī�޶� ��ġ
        DefalutCamera();    //����� ī�޶� ��ġ
    }

    //���� ���� �� ī�޶� ��ġ
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
        //�����߿��� �۵����� ����
        if (gameManager.JumpGamePlayed)
            return;

        //���� ��ġ ����
        Vector3 pos;
        pos = transform.position;

        //ĳ���� ��ġ ��������
        pos.x = target.position.x;
        if (!baseController.IsJump) //���� �߿��� y ��ǥ ��ȯ ����
            pos.y = target.position.y;

        //ī�޶� �� �ۿ� �ȳ����� ���� ����
        pos.x = Mathf.Clamp(pos.x, mapManager.MapSizeMin.x + width, mapManager.MapSizeMax.x - width);
        pos.y = Mathf.Clamp(pos.y, mapManager.MapSizeMin.y + height,mapManager.MapSizeMax.y - height);

        //ī�޶� ��ǥ �־��ֱ�
        transform.position = pos;
    }

}
