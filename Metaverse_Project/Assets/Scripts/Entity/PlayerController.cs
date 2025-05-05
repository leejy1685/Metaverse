using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{


    protected override void Update()
    {
        base.Update();
    }
    protected override void HandleAction()
    {
        //이동
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        //점프
        if (!isJump && Input.GetKeyDown(KeyCode.Space))
        {
            jumpY = statHandler.JumpPower;
            isJump = true;
        }

        //상호작용 물체
        if(ObjectController != null && ObjectController.IsActive)
        {
            if(Input.GetKeyDown(KeyCode.F)) 
                ObjectController.ActiveObject();
        }
    }

}
