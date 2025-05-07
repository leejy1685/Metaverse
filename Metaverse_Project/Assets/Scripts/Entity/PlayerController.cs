using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField] AudioClip JumpSound;
    [SerializeField] GameObject GuidText;

    protected override void Update()
    {
        base.Update();
        Guidancetext();
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
            //sound
            SoundManager.PlayClip(JumpSound);

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

    private void Guidancetext()
    {
        if (ObjectController != null && ObjectController.IsActive)
        {
            GuidText.SetActive(true);
        }
        else
        {
            GuidText.SetActive(false);
        }
    }

}
