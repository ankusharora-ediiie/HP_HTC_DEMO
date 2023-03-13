using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> _sounds_CompleteFlow = new List<AudioClip>();
    public AudioSource _audioSource_CompleteFlow;

    public AudioClip _nextButtonAudioClip;
    public AudioSource _nextButtonAudioSource;

    public List<AudioClip> _textSpeechAudioClip = new List<AudioClip>();
    public AudioSource _textSpeechAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
