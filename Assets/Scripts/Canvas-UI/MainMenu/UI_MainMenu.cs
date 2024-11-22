using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_MainMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject settingsScreen;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;

    [Header("Sound")]
    [SerializeField] private AudioClip click;
    
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI highScore;
    private int highScoreInt;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        GetPreferences();
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClicked()
    {
        UI_AudioControl.Instance.PlaySound(click);
        SceneManager.LoadScene("Game");

    }

    private void OnSettingsButtonClicked()
    {
        UI_AudioControl.Instance.PlaySound(click);
        settingsScreen.SetActive(true);

    }



    public void GetPreferences(){

        highScoreInt = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = highScoreInt.ToString();
    }

}

