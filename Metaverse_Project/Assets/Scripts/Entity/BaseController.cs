using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // 이동을 위한 물리 컴포넌트

    [SerializeField] private SpriteRenderer characterRenderer; // 좌우 반전을 위한 렌더러

    protected Vector2 movementDirection = Vector2.zero; // 현재 이동 방향
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected bool isJump = false;  //점프 판단 여부
    protected float jumpY = 0;  //점프처리에 필요한 변수
    public bool IsJump { get { return isJump; } }

    protected AnimationHandler animationHandler;//애니메이션 처리
    protected StatHandler statHandler;

    [SerializeField] ObjectController objectController;//상호작용
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
        HandleAction(); //캐릭터 조작
        Rotate(movementDirection);  //캐릭터 방향 전환
    }

    protected void FixedUpdate()
    {
        if (gameManager.jumpGameStarted)
        {   //조작 잠시 정지
            moveJumpGamePosition(); //게임 위치로 이동
            return;
        }
        if (gameManager.JumpGamePlayed)
        {
            statHandler.JumpPower = 20;
            Jump();
            return;
        }

        Movement(movementDirection);    //이동
        Jump(); //점프
    }

    protected virtual void HandleAction()
    {

    }

    //이동
    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler.Speed;

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    //방향 전환
    private void Rotate(Vector2 direction)
    {
        if (direction.x == 0)
            return;

        characterRenderer.flipX = direction.x < 0;
    }


    //점프
    private void Jump()
    {
        //점프파워 가져오기
        float jumpPower = statHandler.JumpPower;

        //점프 연산
        if (isJump)
        {
            animationHandler.Jump();
            jumpY += jumpPower / 10f;
            float jump = Mathf.PingPong(jumpY, jumpPower * 2) - jumpPower;
            Vector2 direction = _rigidbody.velocity;
            direction.y = jump;
            _rigidbody.velocity = direction;

            //점프중 충돌 무시
            _rigidbody.isKinematic = true;

            //점프 종료
            if (jumpY >= jumpPower * 5)
            {
                //충돌 무시 종료
                _rigidbody.isKinematic = false;

                isJump = false;
                //애니메이션 종료
                animationHandler.EndJump();
            }
        }
    }

    public void moveJumpGamePosition()
    {
        Vector3 targetPosition = mapManager.JumpGamePosition.position;
        Vector2 velocity = (targetPosition - transform.position).normalized * statHandler.Speed;

        _rigidbody.velocity = velocity;

        //타겟 포지션을 넘어가면 타겟포지션으로 이동시키고 정지
        if (targetPosition.x < transform.position.x &&
            targetPosition.y > transform.position.y)
        {
            _rigidbody.velocity = Vector2.zero;
            transform.position = targetPosition;
            gameManager.jumpGameStarted = false;
            gameManager.JumpGamePlayed = true;  //게임 플레이 중
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
