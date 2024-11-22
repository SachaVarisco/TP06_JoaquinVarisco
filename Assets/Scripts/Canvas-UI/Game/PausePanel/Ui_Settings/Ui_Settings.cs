using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Ui_Settings : MonoBehaviour
{
    [Header("PausePanel")]
    [SerializeField] private GameObject pausePanel;

    [Header("Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider UISlider;

    [Header("Button")]
    [SerializeField] private Button backSetButton;

    [Header("Sound")]
    [SerializeField] private AudioClip click;

    void Start()
    {
        float volume = 1;
        Audio_Controller.Instance.audioMixer.GetFloat("Master", out volume);
        masterSlider.value = Mathf.Pow(10, volume / 20);
        Audio_Controller.Instance.audioMixer.GetFloat("Audio", out volume);
        soundSlider.value = Mathf.Pow(10, volume / 20);
        Music_Controller.Instance.audioMixer.GetFloat("Music", out volume);
        musicSlider.value = Mathf.Pow(10, volume / 20);
        UI_AudioControl.Instance.audioMixer.GetFloat("UI", out volume);
        UISlider.value = Mathf.Pow(10, volume / 20);

        backSetButton.onClick.AddListener(OnBackButtonClicked);
        soundSlider.onValueChanged.AddListener(OnSoundSliderChanged);
        masterSlider.onValueChanged.AddListener(OnMasterSliderChanged);
        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        UISlider.onValueChanged.AddListener(OnUISliderChanged);

    }

    private void OnDestroy()
    {
        backSetButton.onClick.RemoveAllListeners();
        soundSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
        masterSlider.onValueChanged.RemoveAllListeners();
        UISlider.onValueChanged.RemoveAllListeners();
    }

    // volume Functions
    private void OnUISliderChanged(float volume)
    {
        UI_AudioControl.Instance.SetVolume(volume);
    }
    private void OnMasterSliderChanged(float volume)
    {
        Audio_Controller.Instance.SetVolume(volume, "Master");
    }
    private void OnSoundSliderChanged(float volume)
    {
       //Audio_Controller.Instance.PlaySound(click);
        //Cambiar volumen de sonido
        Audio_Controller.Instance.SetVolume(volume, "Audio");
    }
    private void OnMusicSliderChanged(float volume)
    {
        //Audio_Controller.Instance.PlaySound(click);
        //Cambiar volumen de musica
        Music_Controller.Instance.SetVolume(volume);
    }


    private void OnBackButtonClicked()
    {
        UI_AudioControl.Instance.PlaySound(click);
        gameObject.SetActive(false);
        pausePanel.SetActive(true);
    }

}
