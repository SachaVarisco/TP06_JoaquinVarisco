using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PowerUp : MonoBehaviour
{
    [Header("PlayerData")]
    private PlayerData playerData;

    [Header("Particles")]
    [SerializeField] private ParticleSystem invincibleParticles;

    void Awake()
    {
        playerData = GetComponent<Player_Controller>().playerData;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.transform.gameObject.layer)
        {
            case 9: //Health
                
                Audio_Controller.Instance.PlaySound(playerData.healthClip);
                other.gameObject.SetActive(false);
                playerData.RestLife();
                
                break;
            case 13://Coin
                Audio_Controller.Instance.PlaySound(playerData.coinClip);
                other.gameObject.SetActive(false);
                playerData.TakeCoin();
                break;
            case 14://Invinsible
                Audio_Controller.Instance.PlaySound(playerData.invinsibleClip);
                Music_Controller.Instance.PlayMusic(playerData.invinsibleMusic);
                other.gameObject.SetActive(false);
                StartCoroutine(SpawnInvinsibleParticles());
                break;
            case 15: //Triple jump
                Audio_Controller.Instance.PlaySound(playerData.tripleJumpClip);
                other.gameObject.SetActive(false);
                playerData.TripleJump();
                break;
            case 16: //More damage
                Audio_Controller.Instance.PlaySound(playerData.moreDamageClip);
                other.gameObject.SetActive(false);
                playerData.MoreDamage();
            break;
        }
    }
    

    private IEnumerator SpawnInvinsibleParticles(){
        invincibleParticles.Play();
        playerData.MakeInvincible();
        yield return new WaitForSeconds(10);
        invincibleParticles.Stop();
        playerData.MakeInvincible();
        Music_Controller.Instance.PlayMusic(playerData.levelMusic);
    }
}
