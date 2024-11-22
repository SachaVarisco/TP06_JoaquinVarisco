using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Bullet/Data", order = 2)]
public class BulletData : ScriptableObject
{
    [Header("Speed")]
    public float speed;

    [Header("Damage")]
    public float damage;

    [Header("Time")]
    public float lifeTime;

}
