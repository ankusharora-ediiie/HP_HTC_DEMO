using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimationByTrigger(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    public void PlayAnimationByName(string animation)
    {
        animator.Play(animation);
    }
}
