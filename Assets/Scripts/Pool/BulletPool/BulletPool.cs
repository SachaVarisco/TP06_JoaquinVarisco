using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //public static Pool Instance;
    [Header("Player data")]
    [SerializeField] private PlayerData playerData;

    [Header ("Pool")]
    public GameObject BulletPrefab;
    private int ammoBullet;
    private int maxBullet;
    private List<GameObject> BulletList;
    private void Awake()
    {
        playerData.SetAmmo();
        maxBullet = playerData.maxAmmo;
        ammoBullet = playerData.actualAmmo; 
    }
    private void Start()
    {
        BulletList = new List<GameObject>();
        for (int i = 0; i < ammoBullet; i++)
        {
            GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullet.transform.SetParent(gameObject.transform);
            Bullet.SetActive(false);
            BulletList.Add(Bullet);
        }
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in BulletList)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                playerData.actualAmmo--;
                return bullet.gameObject;
            }
        }
        if (BulletList.Count < maxBullet)
        {
            GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            BulletList.Add(Bullet);
            Bullet.transform.SetParent(gameObject.transform);
            StartCoroutine(DestroyBullet(Bullet));
            Debug.Log("Nueva bala " + BulletList.Count);
            return Bullet;
        }
        else
        {
            Debug.Log("No more bullets " + BulletList.Count);
            return null;
        }
    }

    public void ReturnBullet(GameObject Bullet)
    {
        playerData.actualAmmo++;
        Bullet.SetActive(false);
    }

    private IEnumerator DestroyBullet(GameObject Bullet)
    {
        yield return new WaitForSeconds(5f);
        if (!Bullet.activeSelf)
        {
            BulletList.Remove(Bullet);
            Destroy(Bullet);
        }
    }
}
