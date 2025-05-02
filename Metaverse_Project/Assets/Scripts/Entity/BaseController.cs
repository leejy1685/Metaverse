using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // �̵��� ���� ���� ������Ʈ

    [SerializeField] private SpriteRenderer characterRenderer; // �¿� ������ ���� ������

    protected Vector2 movementDirection = Vector2.zero; // ���� �̵� ����
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected bool isJump = false;  //���� �Ǵ� ����
    public bool IsJump { get { return isJump; } }

    protected AnimationHandler animationHandler;//�ִϸ��̼� ó��
    protected StatHandler statHandler;

    protected float jumpY;  //����ó���� �ʿ��� ����

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Update()
    {
        HandleAction(); //ĳ���� ����
        Rotate(movementDirection);  //ĳ���� ���� ��ȯ
    }

    protected void FixedUpdate()
    {
        Movement(movementDirection);    //�̵�
        Jump(); //����
    }

    protected virtual void HandleAction()
    {

    }

    //�̵�
    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler.Speed;

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    //���� ��ȯ
    private void Rotate(Vector2 direction)
    {
        if (direction.x == 0)
            return;

        characterRenderer.flipX = direction.x < 0;
    }


    //����
    private void Jump()
    {
        //�����Ŀ� ��������
        float jumpPower = statHandler.JumpPower;
        
        //���� ����
        if (isJump)
        {
            animationHandler.Jump();
            jumpY += jumpPower / 10f;
            float jump = Mathf.PingPong(jumpY, jumpPower * 2) - jumpPower;
            Vector2 direction = _rigidbody.velocity;
            direction.y = jump;
            _rigidbody.velocity = direction;

            //���� ����
            if (jumpY >= jumpPower * 5)
            {
                isJump = false;
                //�ִϸ��̼� ����
                animationHandler.EndJump();
            }
        }
    }
}
