using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Credits : MonoBehaviour
{
    [Header("PausePanel")]
    [SerializeField] private GameObject pausePanel;

    [Header("Buttons")]
    [SerializeField] private Button backCredButton;

    [Header("Sound")]
    [SerializeField] private AudioClip click;

    void Start()
    {
        backCredButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy()
    {
        backCredButton.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        UI_AudioControl.Instance.PlaySound(click);
        gameObject.SetActive(false);
        pausePanel.SetActive(true);

    }
}
