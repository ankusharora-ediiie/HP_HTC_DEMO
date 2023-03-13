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

    bool fanTray_Text;
    void FanTray_Text_Method()
    {
        if (!fanTray_Text)
        {
            fanTray_Text = true;
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[20];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
    void FanTray_ReverseBool()
    {
        if (fanTray_Text)
        {
            fanTray_Text = false;
        }
    }

    bool managementTool_Text;
    void ManagementTool_Text_Method()
    {
        if (!managementTool_Text)
        {
            managementTool_Text = true;
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[21];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
    void ManagementTool_ReverseBool()
    {
        if (managementTool_Text)
        {
            managementTool_Text = false;
        }
    }


    bool server46_Text;
    void server46_Text_Method()
    {
        if (!server46_Text)
        {
            server46_Text = true;
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[22];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
    void server46_Text_ReverseBool()
    {
        if (server46_Text)
        {
            server46_Text = false;
        }
    }


    bool powerSupply_Text;
    void powerSupply_Text_Method()
    {
        if (!powerSupply_Text)
        {
            powerSupply_Text = true;
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[24];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
    void powerSupply_Text_ReverseBool()
    {
        if (powerSupply_Text)
        {
            powerSupply_Text = false;
        }
    }


    bool intelBay_Text;
    void intelBay_Text_Method()
    {
        if (!intelBay_Text)
        {
            intelBay_Text = true;
            _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[23];
            _soundManager._audioSource_CompleteFlow.pitch = 1f;
            _soundManager._audioSource_CompleteFlow.Stop();
            _soundManager._audioSource_CompleteFlow.Play();
        }
    }
    void intelBay_Text_ReverseBool()
    {
        if (intelBay_Text)
        {
            intelBay_Text = false;
        }
    }
}
