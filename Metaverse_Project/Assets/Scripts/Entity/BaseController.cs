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
    public bool IsJump { get { return isJump; } }

    protected AnimationHandler animationHandler;//애니메이션 처리
    protected StatHandler statHandler;

    protected float jumpY;  //점프처리에 필요한 변수

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Update()
    {
        HandleAction(); //캐릭터 조작
        Rotate(movementDirection);  //캐릭터 방향 전환
    }

    protected void FixedUpdate()
    {
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

            //점프 종료
            if (jumpY >= jumpPower * 5)
            {
                isJump = false;
                //애니메이션 종료
                animationHandler.EndJump();
            }
        }
    }
}
