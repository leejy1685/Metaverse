using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    Rigidbody2D _rigidbody;
    float[] heights = { -2f, -0.5f, 1.5f };
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        //랜덤한 높이에 화살 생성
        Vector3 arrowPostion = arrow.transform.position;
        arrowPostion.y += heights[Random.Range(0,3)];
        arrow.transform.position = arrowPostion;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = Vector2.left * 10;
        _rigidbody.velocity = velocity;

        if(transform.position.x < -16)
        {
            Destroy(gameObject);
        }
    }
}
