using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollEnemy : MonoBehaviour
{
    [Header("Data")]
    private EnemyData enemyData;

    [Header("Player")]
    [SerializeField] private Transform player;

    [Header ("Patroll")]
    [SerializeField] private Transform[] wayPoints;
    private Vector3 objective;
    private Vector2 move;
    private bool canReturn;

    [Header("Shot")]
    private Transform shooter;

    [Header ("Components")]
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    void Start()
    {
        enemyData = GetComponent<EnemyControl>().enemyData;
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        objective = wayPoints[0].position;
        canReturn = true;
        move = enemyData.move;
    }

    void Update()
    {

        Patroll();  
    }

    private void Patroll()
    {
        rb2D.MovePosition(rb2D.position + move * enemyData.speed * Time.deltaTime);

        if (transform.position.x < wayPoints[0].position.x && canReturn || transform.position.x > wayPoints[1].position.x && canReturn)
        {
            canReturn = false;
            move = new Vector2 (-move.x, move.y);

            StartCoroutine("CanTurn"); 
            
        }
    }

    private IEnumerator CanTurn()
    {
        yield return new WaitForSeconds(1);
        canReturn = true ;
    }
}
