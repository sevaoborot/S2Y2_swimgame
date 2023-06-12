using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationThrowing : MonoBehaviour
{
    private Animator mAnimator;
    int IsThrowingHash;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        IsThrowingHash = Animator.StringToHash("IsThrowing");
    }


    void Update()
    {
        bool IsThrowing = mAnimator.GetBool(IsThrowingHash);
        bool ThrowPressed = Input.GetMouseButtonDown(0);

        // if player presses mouse key he Throws
        if (!IsThrowing && ThrowPressed)
        {
            mAnimator.SetBool(IsThrowingHash, true);
        }

        // if player stop pressing mouse key he stops throwing
        if (IsThrowing && !ThrowPressed)
        {
            mAnimator.SetBool(IsThrowingHash, false);
        }
    }
}
