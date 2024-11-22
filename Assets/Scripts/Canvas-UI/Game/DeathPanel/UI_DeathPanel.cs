using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_DeathPanel : MonoBehaviour
{
    [Header ("Player Data")]
    [SerializeField] private PlayerData playerData;

    [Header("Panel")]
    private GameObject deathPanel;

    [Header("Buttons")]
    [SerializeField] private Button restartButton;

    [Header("Sound")]
    [SerializeField] private AudioClip click;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        deathPanel = transform.GetChild(0).gameObject;
        restartButton.onClick.AddListener(OnBackButtonClicked);
    }
    private void Update()
    {
        if (playerData.actualLife <= 0)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        restartButton.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        Audio_Controller.Instance.PlaySound(click);
        SceneManager.LoadScene("Game");

    }
}
