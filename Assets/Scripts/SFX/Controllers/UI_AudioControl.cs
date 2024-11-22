using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UI_AudioControl : MonoBehaviour
{
    public static UI_AudioControl Instance;

    public AudioMixer audioMixer;
    private AudioSource audioSource;



    private void Awake()
    {
        if (UI_AudioControl.Instance == null)
        {
            UI_AudioControl.Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("UI", Mathf.Log10(volume) * 20);
    }
}
