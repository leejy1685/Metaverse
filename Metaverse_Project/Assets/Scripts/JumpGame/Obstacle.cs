using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    Rigidbody2D _rigidbody;
    float[] heights = { -2f, 1.5f };
    GameManager gameManager;

    [SerializeField] AudioClip arrowSound;
    void Start()
    {
        gameManager = GameManager.instance;
        _rigidbody = GetComponent<Rigidbody2D>();

        //������ ���̿� ȭ�� ����
        Vector3 arrowPostion = arrow.transform.position;
        arrowPostion.y += heights[Random.Range(0,2)];
        arrow.transform.position = arrowPostion;

        //sound
        SoundManager.PlayClip(arrowSound);
    }

    private void FixedUpdate()
    {
        Vector2 velocity = Vector2.left * 10;
        _rigidbody.velocity = velocity;

        //��ǥ�� ����ų� ������ ����Ǹ� �ı�
        if(transform.position.x < -16 || !gameManager.JumpGamePlayed)
        {
            Destroy(gameObject);
        }
    }
}
