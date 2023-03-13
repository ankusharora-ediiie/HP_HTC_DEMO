using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExploreParts : MonoBehaviour
{
    public SoundManager _soundManager;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowParts(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    bool showPart = false;
    void Show_Forward_Method()
    {
        if(!showPart)
        {
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[16];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
    void Show_Reverse_Method()
    {
        showPart = false;
    }
    void Show_AntiReverse_Method()
    {
        showPart = true;
    }

    void Show_Backward_Method()
    {
        if (showPart)
        {
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[17];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
}
