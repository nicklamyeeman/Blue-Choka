using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState : MonoBehaviour
{
    public bool isDrunk;
    private NPCAnimation NPCAnimation;

    void Start()
    {
        NPCAnimation = GetComponent<NPCAnimation>();
        isDrunk = NPCAnimation.GetAnimator().GetBool("isDrunk");
    }

    void Update()
    {        
    }

    void SetState(bool state)
    {
        NPCAnimation.GetAnimator().SetBool("isDrunk", state);
        isDrunk = NPCAnimation.GetAnimator().GetBool("isDrunk");
    }
}
