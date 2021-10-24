using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    private Animator animator;
    private NPCState state;

    void Awake()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<NPCState>();
    }

    public void SetWalkingAnimation()
    {
        animator.ResetTrigger("Talking1");
        animator.ResetTrigger("Talking2");
        animator.ResetTrigger("Idle");
        // Debug.Log("Set walking");
        animator.SetTrigger("Walking");
    }

    public void SetIdleAnimation()
    {
        // Debug.Log("Set idle");
        // if (state.isDrunk == false)
            animator.SetTrigger("Idle");
        // else
        //     animator.SetTrigger("IdleDrunk");
    }

    public void SetTalking1()
    {
        // Debug.Log("Set talking 1");
        animator.SetTrigger("Talking1");
    }

    public void SetTalking2()
    {
        // Debug.Log("Set talking 2");
        animator.SetTrigger("Talking2");
    }

    public Animator GetAnimator()
    {
        return animator;
    }

}
