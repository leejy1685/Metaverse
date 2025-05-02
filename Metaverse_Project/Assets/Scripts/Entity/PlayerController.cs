using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
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
    }


}
