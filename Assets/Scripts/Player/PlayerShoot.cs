using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("BulletData")]
    private PlayerData playerData;

    [Header("Pool")]

    [SerializeField] private GameObject pool;

    [Header("Timer")]
    private float currentTime;

    [Header("Gun")]
    private Transform gun;

    private Animator animator;

    private void Awake()
    {
        playerData = GetComponent<Player_Controller>().playerData;
        currentTime = playerData.shotCadency;
        gun = transform.GetChild(1).gameObject.transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (Input.GetKeyDown(playerData.shotKey) && currentTime <= 0)
        {
            animator.SetTrigger("Shoot");
            currentTime = playerData.shotCadency;
        }
    }

    public void Shoot(){
        GameObject Bullet = pool.GetComponent<BulletPool>().GetBullet();
            if (Bullet != null)
            {
                Audio_Controller.Instance.PlaySound(playerData.shootClip);
                Bullet.transform.position = gun.position;
                Bullet.SetActive(true);

            }
    }

}

