using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator �Ķ���� �̸��� �̸� �ؽ÷� ��ȯ�� ĳ�� (���� ����ȭ)
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsJumping = Animator.StringToHash("IsJump");


    [SerializeField] protected Animator animator;    //�ִϸ�����

    //�ִϸ��̼� ������ ���� �������̵� ��Ʈ�ѷ�
    [SerializeField] protected AnimatorOverrideController overrideController;

    protected virtual void Awake()
    {
        // �ִϸ����� ������Ʈ�� �ڽĿ��� ������
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        // �̵� ���� ������ ũ�⸦ �̿��� �����̴� ������ �Ǵ�
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void Jump()  //���� ��
    {
        animator.SetBool(IsJumping, true);
    }

    public void EndJump()   //���� ��
    {
        animator.SetBool(IsJumping, false);
    }

    public void ChangeAnimation(AnimationClip[] order)
    {
        // clips�� �޾ƿ� ���� �Ҵ�
        List<KeyValuePair<AnimationClip, AnimationClip>> clips = new();

        // Ű�� ��������
        overrideController.GetOverrides(clips);

        //�ִϸ��̼� �־��ֱ�
        for (int i=0;i<order.Length;i++) 
        {
            clips[i] = new KeyValuePair<AnimationClip, AnimationClip>(clips[i].Key, order[i]);
        }

        // �����ϱ�
        overrideController.ApplyOverrides(clips);

        // �������� �ִϸ����Ϳ� �����ϱ�
        animator.runtimeAnimatorController = overrideController;
    }

}
