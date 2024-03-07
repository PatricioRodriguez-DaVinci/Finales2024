using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Audio Manager")]
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _source;

    public void SetMusicVolume(float sliderValue)
    {
        _mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXVolume(float sliderValue)
    {
        _mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }

    public void PlayAudio(AudioClip clip)
    {
        if(_source.clip != clip)
        {
            _source.Stop();
            _source.clip = clip;
            _source.Play();
        }
        else
        {
            return;
        }
    }
}
