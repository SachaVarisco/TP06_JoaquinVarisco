using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Victory : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button backMenuButton;

    [Header("Sound")]
    [SerializeField] private AudioClip click;

    void Start()
    {
        backMenuButton.onClick.AddListener(OnBackMenuButtonClicked);
    }

    private void OnDestroy()
    {
        backMenuButton.onClick.RemoveAllListeners();
    }

    private void OnBackMenuButtonClicked()
    {
        UI_AudioControl.Instance.PlaySound(click);
        SceneManager.LoadScene("Menu");

    }
}
