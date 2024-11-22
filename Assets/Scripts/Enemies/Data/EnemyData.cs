using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyrData", menuName = "Enemy/Data", order = 2)]

public class EnemyData : ScriptableObject
{
    [Header("EnemyLife")]
    public int life;

    [Header("Patroll")]
    public float speed;
    public Vector2 move;
    public float minDistance;

    [Header("Audio")]
    public AudioClip damagedClip;
    public AudioClip deathClip;

}
