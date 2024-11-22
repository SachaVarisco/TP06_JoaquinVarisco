using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [Header("PlayerData")]
    public PlayerData playerData;

    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerData.ResetData();
    }
    private void Update()
    {
        if (playerData.actualLife <= 0)
        {
            Audio_Controller.Instance.PlaySound(playerData.deathClip);
            animator.Play("Death");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.gameObject.layer)
        {
            case 7: //Enemy
                if (playerData.invincible)
                {
                    collision.gameObject.GetComponent<EnemyControl>().TakeDamage();
                    return;
                }
                if (playerData.actualLife > 0)
                {
                    Damaged(collision);
                }

                
                break;
            case 11: //Victory flag
                playerData.SavePreferences();
                SceneManager.LoadScene("Victory");
                break;
            case 12: //Spikes
                if (!playerData.invincible)
                {
                    Damaged(collision);
                }
                break;
            
            

        }
    }

    public void StopForces()
    {
        rb2D.velocity = new Vector2(0, 0);
    }

    private void Damaged(Collision2D collision)
    {
        Audio_Controller.Instance.PlaySound(playerData.damagedClip);
        rb2D.velocity = new Vector2(-playerData.impactVelocity.x * collision.GetContact(0).normal.x, playerData.impactVelocity.y);
        animator.SetTrigger("Damaged");
        playerData.TakeDamage();
    }

}
