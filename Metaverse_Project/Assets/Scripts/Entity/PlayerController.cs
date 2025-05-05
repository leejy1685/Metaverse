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

        //��ȣ�ۿ� ��ü
        if(ObjectController != null && ObjectController.IsActive)
        {
            if(Input.GetKeyDown(KeyCode.F)) 
                ObjectController.ActiveObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        if (collision.CompareTag("Arrow"))
        {
            gameManager.JumpGameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D (collision);
        if (collision.CompareTag("Obstacle"))
        {
            gameManager.addJumpGamePoint();
        }
    }

}
