using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    private BaseController baseController;
    
    void Awake()
    {
        if (target == null) //타겟이 없으면 실행하지 않음
            return;

        baseController = target.GetComponent<BaseController>();
    }

    void FixedUpdate()
    {
        if (target == null) //타겟이 없으면 실행하지 않음
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        if(!baseController.IsJump)
            pos.y = target.position.y;
        transform.position = pos;
    }
}
