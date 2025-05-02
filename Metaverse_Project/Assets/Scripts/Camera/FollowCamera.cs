using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    private BaseController baseController;
    
    void Awake()
    {
        if (target == null) //Ÿ���� ������ �������� ����
            return;

        baseController = target.GetComponent<BaseController>();
    }

    void FixedUpdate()
    {
        if (target == null) //Ÿ���� ������ �������� ����
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        if(!baseController.IsJump)
            pos.y = target.position.y;
        transform.position = pos;
    }
}
