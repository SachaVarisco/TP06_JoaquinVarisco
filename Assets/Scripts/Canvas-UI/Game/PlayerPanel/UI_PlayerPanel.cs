using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerPanel : MonoBehaviour
{
    [Header ("PlayerData")] 
    [SerializeField] private PlayerData playerData;

    [Header("Sprites")]
    [SerializeField] private Sprite[] UIPlayerSprites;

    [Header("Images")]
    [SerializeField] private Image[] healthBars;
    [SerializeField] private Image[] ammoBars;

    [Header("Blabla")]
    private int ammoUI;
    private int lifeUI;

    [Header ("Score")]
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText; 

    void Start()
    {
        playerData.RestLife();
        lifeUI = playerData.actualLife;
        ammoUI = playerData.actualAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerData.actualLife < 0)
        {
            return;
        }
        if (lifeUI != playerData.actualLife)
        {
            if (playerData.actualLife > lifeUI)
            {
                for (int i = 0; i < playerData.actualLife;  i++)
                {
                    healthBars[i].sprite = UIPlayerSprites[0];
                }
            }
            else
            {
                healthBars[playerData.actualLife].sprite = UIPlayerSprites[1];
            }
            lifeUI = playerData.actualLife;
        }

        if (score != playerData.coinScore)
        {
            score = playerData.coinScore;
            scoreText.text = score.ToString();
        }

        if (ammoUI != playerData.actualAmmo)
        {
            if (playerData.actualAmmo > ammoUI)
            {
                ammoBars[playerData.actualAmmo - 1].sprite = UIPlayerSprites[2];
            }
            else
            {
                ammoBars[playerData.actualAmmo].sprite = UIPlayerSprites[3];
            }
            ammoUI = playerData.actualAmmo;
        }
    }
}
