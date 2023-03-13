using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    Animator animator;
    public GameObject Aruba_Server;
    public GameObject Next_Button;
    public List<GameObject> highlightedObjects = new List<GameObject>();

    public List<GameObject> partsToDisable = new List<GameObject>();
    public GameObject exploreModeObject;

    public SoundManager _soundManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void EnableGameObject()
    {
        if (Aruba_Server != null && Next_Button != null)
        {
            Aruba_Server.SetActive(true);
            Next_Button.SetActive(true);
        }
    }

    void DisableGameObject()
    {
        if (Next_Button != null) Next_Button.SetActive(false);
    }

    void EnableHighlight()
    {
        for (int i = 0; i < highlightedObjects.Count; i++)
        {
            highlightedObjects[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    void EnableExploreModeObject()
    {
        exploreModeObject.SetActive(true);
        for (int i = 0; i < partsToDisable.Count; i++)
        {
            partsToDisable[i].SetActive(false);
        }

    }

    void EdiiieLogo_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[0];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void InGram_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[1];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void Aruba_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[2];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_PopUp_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[3];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_FrontToBack_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[4];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_FanTrayOpen_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[5];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_PowerIntelBays_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[6];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_BackToFront_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[7];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_PowerSupply_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[8];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_ModuleS4SFP56_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[9];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_ManagementTool_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[10];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_Explore_Sound_1_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[11];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_Explore_Sound_2_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[12];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_Explore_Sound_3_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[13];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_Explore_Sound_4_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[14];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }

    void MainServer_Explore_Sound_5_Method()
    {
        _soundManager._audioSource_CompleteFlow.clip = _soundManager._sounds_CompleteFlow[15];
        _soundManager._audioSource_CompleteFlow.pitch = 1f;
        _soundManager._audioSource_CompleteFlow.Stop();
        _soundManager._audioSource_CompleteFlow.Play();
    }





    void MainServer_Part_1_Text_Sound_1_Method()
    {
        _soundManager._textSpeechAudioSource.clip = _soundManager._textSpeechAudioClip[0];
        _soundManager._textSpeechAudioSource.pitch = 1f;
        _soundManager._textSpeechAudioSource.Stop();
        _soundManager._textSpeechAudioSource.Play();
    }

    void MainServer_Part_2_Text_Sound_1_Method()
    {
        _soundManager._textSpeechAudioSource.clip = _soundManager._textSpeechAudioClip[1];
        _soundManager._textSpeechAudioSource.pitch = 1f;
        _soundManager._textSpeechAudioSource.Stop();
        _soundManager._textSpeechAudioSource.Play();
    }

    void MainServer_Part_3_Text_Sound_1_Method()
    {
        _soundManager._textSpeechAudioSource.clip = _soundManager._textSpeechAudioClip[2];
        _soundManager._textSpeechAudioSource.pitch = 1f;
        _soundManager._textSpeechAudioSource.Stop();
        _soundManager._textSpeechAudioSource.Play();
    }

    void MainServer_Part_4_Text_Sound_1_Method()
    {
        _soundManager._textSpeechAudioSource.clip = _soundManager._textSpeechAudioClip[3];
        _soundManager._textSpeechAudioSource.pitch = 1f;
        _soundManager._textSpeechAudioSource.Stop();
        _soundManager._textSpeechAudioSource.Play();
    }

    void MainServer_Part_5_Text_Sound_1_Method()
    {
        _soundManager._textSpeechAudioSource.clip = _soundManager._textSpeechAudioClip[4];
        _soundManager._textSpeechAudioSource.pitch = 1f;
        _soundManager._textSpeechAudioSource.Stop();
        _soundManager._textSpeechAudioSource.Play();
    }

    void MainServer_Part_6_Text_Sound_1_Method()
    {
        _soundManager._textSpeechAudioSource.clip = _soundManager._textSpeechAudioClip[5];
        _soundManager._textSpeechAudioSource.pitch = 1f;
        _soundManager._textSpeechAudioSource.Stop();
        _soundManager._textSpeechAudioSource.Play();
    }
}