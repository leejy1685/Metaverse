using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager instance;

    //���� ���� ����
    public bool jumpGameStarted { get; set; }
    public bool JumpGamePlayed {  get; set; }



    [SerializeField] PlayerController playerController;

    private void Awake()
    {
        //�̱��� �Ҵ�
        instance = this;
    }

}
