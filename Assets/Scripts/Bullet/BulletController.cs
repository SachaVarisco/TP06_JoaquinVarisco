
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("BulletData")]
    [SerializeField] private BulletData bulletData;

    [Header("Pool")]
    [SerializeField] private BulletPool pool;

    [Header("Player")]
    [SerializeField] private Transform playerLook;

    [Header("Timer")]
    private float currentTime;
    [Header("Direction")]
    private Vector2 direction;
    private bool canMove;

    [Header("Components")]

    private SpriteRenderer SR;
    private Rigidbody2D rb2D;
    [SerializeField] private ParticleSystem partSystem;


    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        //playerLook = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        SR.enabled = true;
        canMove = true;
        currentTime = bulletData.lifeTime;
        if (playerLook.localScale.x < 0)
        {
            direction = -transform.right;
        }
        else
        {
            direction = transform.right;
        }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (canMove)
        {
            rb2D.velocity = direction * bulletData.speed;
        }
        
        if (currentTime <= 0)
        {
            pool.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)//Enemy
        {
            canMove = false;
            other.gameObject.GetComponent<EnemyControl>().TakeDamage();
            StartCoroutine("PlayParticles");
        }
        
    }

    private IEnumerator PlayParticles()
    {
        SR.enabled = false;
        partSystem.Play();
        yield return new WaitForSeconds(0.1f);
        pool.ReturnBullet(gameObject);
    }
}
