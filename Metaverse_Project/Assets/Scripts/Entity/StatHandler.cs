using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    // 이동 속도 (1f ~ 20f 사이 값만 허용)
    [Range(1f, 20f)][SerializeField] private float speed = 5;
    // 외부에서 접근 가능한 프로퍼티 (값 변경 시 0~20f로 제한)
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }

    // 이동 속도 (1f ~ 20f 사이 값만 허용)
    [Range(1f, 10f)][SerializeField] private float jumpPower = 5;
    // 외부에서 접근 가능한 프로퍼티 (값 변경 시 0~20f로 제한)
    public float JumpPower
    {
        get => jumpPower;
        set => jumpPower = Mathf.Clamp(value, 0, 10);
    }
}
