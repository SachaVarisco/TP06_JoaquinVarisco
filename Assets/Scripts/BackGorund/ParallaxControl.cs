using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxControl : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private SpriteRenderer backBuilds;
    [SerializeField] private SpriteRenderer midBuidls;
    [SerializeField] private SpriteRenderer nearBuilds;
    [SerializeField] private SpriteRenderer frontBuilds;

    [Header("Transforms")]

    [SerializeField] private Transform BB;
    [SerializeField] private Transform MB;
    [SerializeField] private Transform NB;
    [SerializeField] private Transform FB;


    [Header("Player")]
    [SerializeField] private GameObject player;
    private Player_Move playerMove;
    private Vector2 playerSpeed;


    [Header("Speed")]
    [SerializeField] private Vector2 speedMove;

    private Vector2 offset;
    private Material materialSky;
    private Material materialBB;
    private Material materialMB;
    private Material materialNB;
    private Material materialFB;

    private void Awake()
    { 
        playerMove = player.GetComponent<Player_Move>();   

        materialBB = backBuilds.material;
        materialMB = midBuidls.material;
        materialNB = nearBuilds.material;
        materialFB = frontBuilds.material;
    }
    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x, transform.position.y);

        offset = speedMove * Time.deltaTime;

        playerSpeed = playerMove.CheckSpeed();

        materialBB.mainTextureOffset += new Vector2((offset.x * (playerSpeed.x / 10)), 0);
        materialMB.mainTextureOffset += new Vector2((offset.x * (playerSpeed.x / 3)),0);
        materialNB.mainTextureOffset += new Vector2((offset.x * (playerSpeed.x / 1.5f)), 0);
        materialFB.mainTextureOffset += new Vector2((offset.x * (playerSpeed.x * 1.5f)), 0);

        /*BB.position = new Vector2(BB.position.x, player.transform.position.y);
        MB.position = new Vector2(BB.position.x, player.transform.position.y);
        NB.position = new Vector2(BB.position.x, player.transform.position.y);
        FB.position = new Vector2(BB.position.x, player.transform.position.y);*/


    }
}
