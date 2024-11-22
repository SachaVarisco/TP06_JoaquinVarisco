using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data",order = 1)]
public class PlayerData : ScriptableObject
{
    [Header ("Life")]
    public int maxLife;
    public int actualLife;

    [Header("DamageRebound")]
    public Vector2 impactVelocity;

    [Header ("Movement")]
    public float walkSpeed;
    public float runSpeed;

    [Header("Jump")]
    public KeyCode jumpKey;
    public float jumpForce;
    public float gravity;
    public float feetRadius;
    public LayerMask ground;
    public bool inGround;

    public int jumpCount;
    public int maxJump;

    [Header("Shot")]
    public KeyCode shotKey; 
    public float shotCadency;
    public int maxAmmo;
    public int actualAmmo;
    public int ammoDamage;

    [Header("Coin")]
    public int coinScore;
    public int coinHighScore;

    [Header("Music")]

    public AudioClip invinsibleMusic;
    public AudioClip levelMusic;

    [Header("Sounds")]
    public AudioClip jumpClip;
    public AudioClip landClip;
    public AudioClip shootClip;
    public AudioClip damagedClip;
    public AudioClip deathClip;
    public AudioClip healthClip;
    public AudioClip coinClip;
    public AudioClip tripleJumpClip;
    public AudioClip invinsibleClip;
    public AudioClip moreDamageClip;

    [Header("Invincible")]
    public bool invincible; 


    public void ResetData(){
        actualLife = maxLife;
        maxJump = 1;
        jumpCount = maxJump;
        coinScore = 0;
        ammoDamage = 1;
        invincible = false;
    }

    public void TakeDamage(){
        actualLife--;
    }

    public void RestLife()
    {
        actualLife = maxLife;
    }

    public void SetAmmo()
    {
        actualAmmo = maxAmmo;
    }

    public void TakeCoin(){
        coinScore += 10;
    }

    public void TripleJump(){
        maxJump++;
    }

    public void MoreDamage(){
        ammoDamage = 3;
    }

    public void MakeInvincible(){
        if (!invincible)
        {
            invincible = true;
        }else{
            invincible = false;
        }
        
    }

    //Player Prefs
    public void GetPreferences(){
        coinHighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void SavePreferences(){
        if (coinHighScore < coinScore)
        {
            coinHighScore = coinScore;
            PlayerPrefs.SetInt("HighScore", coinHighScore);
            PlayerPrefs.Save();
        }
       
    }
}
