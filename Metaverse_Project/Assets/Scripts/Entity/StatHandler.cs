using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    // �̵� �ӵ� (1f ~ 20f ���� ���� ���)
    [Range(1f, 20f)][SerializeField] private float speed = 5;
    // �ܺο��� ���� ������ ������Ƽ (�� ���� �� 0~20f�� ����)
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }

    // �̵� �ӵ� (1f ~ 20f ���� ���� ���)
    [Range(1f, 10f)][SerializeField] private float jumpPower = 5;
    // �ܺο��� ���� ������ ������Ƽ (�� ���� �� 0~20f�� ����)
    public float JumpPower
    {
        get => jumpPower;
        set => jumpPower = Mathf.Clamp(value, 0, 10);
    }
}
