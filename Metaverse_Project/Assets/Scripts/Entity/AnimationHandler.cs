using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator 파라미터 이름을 미리 해시로 변환해 캐싱 (성능 최적화)
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsJumping = Animator.StringToHash("IsJump");


    [SerializeField] protected Animator animator;    //애니메이터

    //애니메이션 변경을 위한 오버라이드 컨트롤러
    [SerializeField] protected AnimatorOverrideController overrideController;

    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트를 자식에서 가져옴
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        // 이동 방향 벡터의 크기를 이용해 움직이는 중인지 판단
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void Jump()  //점프 중
    {
        animator.SetBool(IsJumping, true);
    }

    public void EndJump()   //점프 끝
    {
        animator.SetBool(IsJumping, false);
    }

    public void ChangeAnimation(AnimationClip[] order)
    {
        // clips를 받아올 공간 할당
        List<KeyValuePair<AnimationClip, AnimationClip>> clips = new();

        // 키값 가져오기
        overrideController.GetOverrides(clips);

        //애니메이션 넣어주기
        for (int i=0;i<order.Length;i++) 
        {
            clips[i] = new KeyValuePair<AnimationClip, AnimationClip>(clips[i].Key, order[i]);
        }

        // 적용하기
        overrideController.ApplyOverrides(clips);

        // 실행중인 애니메이터에 적용하기
        animator.runtimeAnimatorController = overrideController;
    }

}
