using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;

    public SoundManager _soundManager;
    public void PlayAnimationByTrigger(string animationName)
    {
        animator.SetTrigger(animationName);
        _soundManager._nextButtonAudioSource.clip = _soundManager._nextButtonAudioClip;
        _soundManager._nextButtonAudioSource.pitch = 1f;
        _soundManager._nextButtonAudioSource.Stop();
        _soundManager._nextButtonAudioSource.Play();
    }

    public void PlayAnimationByName(string animation)
    {
        animator.Play(animation);
    }
}
