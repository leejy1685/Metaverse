using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject arrow;  //화살 
    Rigidbody2D _rigidbody; // 장애물 이동을 위한 리지드 바디
    float[] heights = { -2f, 1.5f };    //화살 위치
    GameManager gameManager;    //게임 작동여부 판단을 위한 게임 매니저

    [SerializeField] AudioClip arrowSound;  //화살 소리
    void Start()
    {
        //필요한 정보 가져오기
        gameManager = GameManager.instance;
        _rigidbody = GetComponent<Rigidbody2D>();

        //랜덤한 높이에 화살 생성
        Vector3 arrowPostion = arrow.transform.position;
        arrowPostion.y += heights[Random.Range(0,2)];
        arrow.transform.position = arrowPostion;

        //sound
        SoundManager.PlayClip(arrowSound);
    }

    private void FixedUpdate()
    {
        //화살 날아가는 속도는 10 나중에 레벨 개념이 생기면 변수로 작용
        Vector2 velocity = Vector2.left * 10;
        _rigidbody.velocity = velocity;

        //좌표를 벗어나거나 게임이 종료되면 파괴
        if(transform.position.x < -16 || !gameManager.JumpGamePlayed)
        {
            Destroy(gameObject);
        }
    }
}
