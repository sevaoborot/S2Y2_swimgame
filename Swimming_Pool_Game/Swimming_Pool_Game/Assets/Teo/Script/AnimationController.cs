using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    private Animator mAnimator;
    int IsRunningHash;
    int IsJumpingHash;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        IsRunningHash = Animator.StringToHash("IsRunning");
        IsJumpingHash = Animator.StringToHash("IsJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsJumping = mAnimator.GetBool(IsJumpingHash);
        bool IsRunning = mAnimator.GetBool(IsRunningHash);
        bool ForwardPressed = Input.GetKey(KeyCode.W);
        bool JumpPressed = Input.GetKey(KeyCode.Space);

        // if player presses W key he runnes
        if (!IsRunning && ForwardPressed)
        {
            mAnimator.SetBool(IsRunningHash, true);
        }

        // if player stop pressing w key he stops running
        if (IsRunning && !ForwardPressed)
        {
            mAnimator.SetBool(IsRunningHash, false);
        }

        //if player is running and you press space he jumps
        if (!IsJumping && (ForwardPressed && JumpPressed))
        {
            mAnimator.SetBool(IsJumpingHash, true);
        }

        //if player is not running and you press jump he does not jump
        if (IsJumping && (!ForwardPressed || !JumpPressed))
        {
            mAnimator.SetBool(IsJumpingHash, false);
        }

    }
}