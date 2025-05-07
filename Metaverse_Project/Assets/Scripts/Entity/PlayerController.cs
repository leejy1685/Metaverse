using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField] AudioClip JumpSound;   //���� �Ҹ�
    [SerializeField] GameObject GuidText;   //�ȳ� ���� 

    protected override void Update()
    {
        base.Update();
        Guidancetext(); //�ȳ� ���� �۵�
    }

    protected void FixedUpdate()
    {
        base.FixedUpdate();
        StartJumpGame();    //���� ����
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
            //sound
            SoundManager.PlayClip(JumpSound);

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

        //���� ���� �����ǰ� �浹�ϸ� Ÿ������������ �̵���Ű�� ����
        if (gameManager.jumpGameStarted && collision.CompareTag("JumpGamePosition"))
        {
            _rigidbody.velocity = Vector2.zero;
            transform.position = mapManager.JumpGamePosition.position;
            gameManager.jumpGameStarted = false;
            gameManager.JumpGamePlayed = true;  //���� �÷��� ��
        }

        //ȭ�쿡 ������ ���� ����
        if (collision.CompareTag("Arrow"))
        {
            gameManager.JumpGameOver();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D (collision);

        //ȭ�� ��ֹ��� ���ϸ� ���� �߰�
        if (collision.CompareTag("Obstacle"))
        {
            gameManager.addJumpGamePoint();
        }
    }

    //��ȣ�ۿ� ������ ��ü�� ������ �� �ȳ� ����
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

    //���� ����
    public void StartJumpGame()
    {
        if (gameManager.jumpGameStarted)//���� ���� ��ġ�� �̵�
        {
            Vector3 targetPosition = mapManager.JumpGamePosition.position;
            Vector2 direction = (targetPosition - transform.position).normalized;

            Movement(direction);
        }
        if (gameManager.JumpGamePlayed)//���� ���� �� ������ 20
        {
            statHandler.JumpPower = 20;
        }
    }

}
