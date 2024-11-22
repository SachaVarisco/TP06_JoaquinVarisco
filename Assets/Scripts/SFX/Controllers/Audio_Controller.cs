using UnityEngine;
using UnityEngine.Audio;

public class Audio_Controller : MonoBehaviour
{
    public static Audio_Controller Instance;

    public AudioMixer audioMixer;
    private AudioSource audioSource;



    private void Awake()
    {
       if (Audio_Controller.Instance == null)
        {
            Audio_Controller.Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }  else
        {
            Destroy(gameObject);
        } 
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio){
        audioSource.PlayOneShot(audio);
    }

    public void SetVolume(float volume, string pitch){
        audioMixer.SetFloat(pitch, Mathf.Log10(volume) * 20);
    }
}
