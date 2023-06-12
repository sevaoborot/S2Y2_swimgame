using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerCrouch : MonoBehaviour
{
    private Animator mAnimator;
    int IsCrouchHash;
    int IsCrouchWalkingHash;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        IsCrouchHash = Animator.StringToHash("IsCrouch");
        IsCrouchWalkingHash = Animator.StringToHash("IsCrouchWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsCrouchWalking = mAnimator.GetBool(IsCrouchWalkingHash);
        bool IsCrouch = mAnimator.GetBool(IsCrouchHash);
        bool CrouchPressed = Input.GetKey(KeyCode.C);
        bool CrouchWPressed = Input.GetKey(KeyCode.W);

        // if player presses C key he Crouch
        if (!IsCrouch && CrouchPressed)
        {
            mAnimator.SetBool(IsCrouchHash, true);
        }

        // if player stop pressing c key he stops crouching
        if (IsCrouch && !CrouchPressed)
        {
            mAnimator.SetBool(IsCrouchHash, false);
        }

        //if player is crouch and you press w he crouchwalks
        if (!IsCrouchWalking && (!CrouchPressed && CrouchWPressed))
        {
            mAnimator.SetBool(IsCrouchWalkingHash, true);
        }

        //if player is  crouching and you stop pressing W he stops crouchwalking
        if (IsCrouchWalking && (CrouchPressed || !CrouchWPressed))
        {
            mAnimator.SetBool(IsCrouchWalkingHash, false);
        }
    }
}
