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
    protected float jumpY = 0;  //����ó���� �ʿ��� ����
    public bool IsJump { get { return isJump; } }

    protected AnimationHandler animationHandler;//�ִϸ��̼� ó��
    protected StatHandler statHandler;

    [SerializeField] ObjectController objectController;//��ȣ�ۿ�
    protected ObjectController ObjectController { get { return objectController; } }

    protected GameManager gameManager;
    protected MapManager mapManager;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
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
        if (gameManager.jumpGameStarted)
        {   //���� ��� ����
            moveJumpGamePosition(); //���� ��ġ�� �̵�
            return;
        }
        if (gameManager.JumpGamePlayed)
        {
            statHandler.JumpPower = 20;
            Jump();
            return;
        }

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

    public void moveJumpGamePosition()
    {
        Vector3 targetPosition = mapManager.JumpGamePosition.position;
        Vector2 velocity = (targetPosition - transform.position).normalized * statHandler.Speed;

        _rigidbody.velocity = velocity;

        //Ÿ�� �������� �Ѿ�� Ÿ������������ �̵���Ű�� ����
        if (targetPosition.x < transform.position.x &&
            targetPosition.y > transform.position.y)
        {
            _rigidbody.velocity = Vector2.zero;
            transform.position = targetPosition;
            gameManager.jumpGameStarted = false;
            gameManager.JumpGamePlayed = true;  //���� �÷��� ��
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectController = collision.collider.GetComponent<ObjectController>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objectController = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         objectController = collision.GetComponent<ObjectController>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectController = null;
    }

}
