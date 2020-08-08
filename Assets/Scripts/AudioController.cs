using UnityEngine;

public class AudioController : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private AudioSource _audioSource1, _audioSource2, _audioSource3;

    public AudioClip buttonSelect;
    [Range(0,1)] public float buttonSelectVolume = 1;
    public bool buttonSelectPlayOnAwake = true;
    public bool buttonSelectLoop = true; 

    public AudioClip buttonPress;
    [Range(0,1)] public float buttonPressVolume = 1;
    public bool buttonPressPlayOnAwake = true;
    public bool buttonPressLoop = true;

    public AudioClip backgroundMusic;
    [Range(0,1)] public float bgmVolume = 1;
    public bool bgmPlayOnAwake = true;
    public bool bgmLoop = true;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private void Start()
    {
        _audioSource1 = AddAudio(buttonSelect, buttonSelectVolume, buttonSelectPlayOnAwake, buttonSelectLoop);
        _audioSource2 = AddAudio(buttonPress, buttonPressVolume, buttonPressPlayOnAwake, buttonPressLoop);
    }

// -------------------------------------------------------------------------------------------------

    private AudioSource AddAudio(AudioClip audioClip, float volume, bool playOnAwake, bool loop)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = audioClip;
        newAudio.volume = volume;
        newAudio.playOnAwake = playOnAwake;
        newAudio.loop = loop;

        return newAudio;
    }

// --------------------------------------------------------------------------------------------------

    public void ButtonSelect()
    {
        _audioSource1.Play();
    }

// --------------------------------------------------------------------------------------------------

    public void ButtonPress()
    {
        _audioSource2.Play();
    }
}
