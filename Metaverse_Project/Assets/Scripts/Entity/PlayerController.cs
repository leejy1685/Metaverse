using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    protected override void HandleAction()
    {
        //�̵�
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        //����
        if (!isJump && Input.GetKeyDown(KeyCode.Space))
        {
            jumpY = statHandler.JumpPower;
            isJump = true;
        }
    }


}
