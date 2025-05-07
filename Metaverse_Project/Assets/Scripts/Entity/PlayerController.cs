using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField] AudioClip JumpSound;   //점프 소리
    [SerializeField] GameObject GuidText;   //안내 문구 

    protected override void Update()
    {
        base.Update();
        Guidancetext(); //안내 문구 작동
    }

    protected void FixedUpdate()
    {
        base.FixedUpdate();
        StartJumpGame();    //점프 게임
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

        //점프 게임 포지션과 충돌하면 타겟포지션으로 이동시키고 정지
        if (gameManager.jumpGameStarted && collision.CompareTag("JumpGamePosition"))
        {
            _rigidbody.velocity = Vector2.zero;
            transform.position = mapManager.JumpGamePosition.position;
            gameManager.jumpGameStarted = false;
            gameManager.JumpGamePlayed = true;  //게임 플레이 중
        }

        //화살에 맞으면 게임 종료
        if (collision.CompareTag("Arrow"))
        {
            gameManager.JumpGameOver();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D (collision);

        //화살 장애물을 피하면 점수 추가
        if (collision.CompareTag("Obstacle"))
        {
            gameManager.addJumpGamePoint();
        }
    }

    //상호작용 가능한 물체를 만났을 때 안내 문구
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

    //점프 게임
    public void StartJumpGame()
    {
        if (gameManager.jumpGameStarted)//점프 게임 위치로 이동
        {
            Vector3 targetPosition = mapManager.JumpGamePosition.position;
            Vector2 direction = (targetPosition - transform.position).normalized;

            Movement(direction);
        }
        if (gameManager.JumpGamePlayed)//점프 게임 시 점프력 20
        {
            statHandler.JumpPower = 20;
        }
    }

}
