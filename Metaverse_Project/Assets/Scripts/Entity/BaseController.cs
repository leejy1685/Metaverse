using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // �̵��� ���� ���� ������Ʈ

    [SerializeField] protected SpriteRenderer characterRenderer; // �¿� ������ ���� ������


    //�̵� ����
    protected Vector2 movementDirection = Vector2.zero; 
    public Vector2 MovementDirection { get { return movementDirection; } }


    //���� ����
    protected bool isJump = false;  //���� �Ǵ� ����
    public bool IsJump { get { return isJump; } }
    protected float jumpY = 0;  //����ó���� �ʿ��� ����

    //�ִϸ��̼� ����
    protected AnimationHandler animationHandler;

    //���� ����
    protected StatHandler statHandler;

    //��ȣ�ۿ� ����
    [SerializeField] ObjectController objectController;
    protected ObjectController ObjectController { get { return objectController; } }

    //�Ŵ�����
    protected GameManager gameManager;
    protected MapManager mapManager;

    protected virtual void Start()
    {
        //ĳ���� ����
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();

        //�ʼ� �Ŵ���
        gameManager = GameManager.instance;
        mapManager = MapManager.instance;
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
    protected void Movement(Vector2 direction)
    {
        if (gameManager.JumpGamePlayed)
            return;

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
            direction.x = 0;

            _rigidbody.velocity = direction;

            //������ �浹 ����
            _rigidbody.isKinematic = true;

            //���� ����
            if (jumpY >= jumpPower * 5)
            {
                //�浹 ���� ����
                _rigidbody.isKinematic = false;

                isJump = false;
                //�ִϸ��̼� ����
                animationHandler.EndJump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   //��ȣ�ۿ� ��ü
        objectController = collision.collider.GetComponent<ObjectController>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objectController = null;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
         objectController = collision.GetComponent<ObjectController>();
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        objectController = null;
    }

}
