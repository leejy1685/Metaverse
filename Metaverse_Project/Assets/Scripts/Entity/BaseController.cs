using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // 이동을 위한 물리 컴포넌트

    [SerializeField] protected SpriteRenderer characterRenderer; // 좌우 반전을 위한 렌더러


    //이동 구현
    protected Vector2 movementDirection = Vector2.zero; 
    public Vector2 MovementDirection { get { return movementDirection; } }


    //점프 구현
    protected bool isJump = false;  //점프 판단 여부
    public bool IsJump { get { return isJump; } }
    protected float jumpY = 0;  //점프처리에 필요한 변수

    //애니메이션 구현
    protected AnimationHandler animationHandler;

    //스탯 구현
    protected StatHandler statHandler;

    //상호작용 구현
    [SerializeField] ObjectController objectController;
    protected ObjectController ObjectController { get { return objectController; } }

    //매니저들
    protected GameManager gameManager;
    protected MapManager mapManager;

    protected virtual void Start()
    {
        //캐릭터 구현
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();

        //필수 매니저
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
        Movement(movementDirection);    //이동
        Jump(); //점프
    }

    protected virtual void HandleAction()
    {

    }

    //이동
    protected void Movement(Vector2 direction)
    {
        if (gameManager.JumpGamePlayed)
            return;

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
            direction.x = 0;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {   //상호작용 객체
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
