using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music_Controller : MonoBehaviour
{
    public static Music_Controller Instance;

    [Header ("Component")]
    private AudioSource audioSource;

    [Header("AudioMixer")]
    public AudioMixer audioMixer;

    [Header("Song")]
    [SerializeField] private AudioClip Game;
    
    private void Awake()
    {
        if (Music_Controller.Instance == null)
        {
            Music_Controller.Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;

        PlayAwake();

    }
    

    public void PlayAwake(){
        PlayMusic(Game);
    }
    public void PlayMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
        audioSource.loop = true;
    }
    public void StopMusic(){
        audioSource.Stop();
    }

    public void SetVolume(float volume){
        //audioSource.volume = volume;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

}
