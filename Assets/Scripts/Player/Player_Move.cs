using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [Header("PlayerData")]
    private PlayerData playerData;
   
    [Header("Movement")]
    private bool isRun;
    public float horizontalMove;
    private float speed;
    
    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerData = GetComponent<Player_Controller>().playerData;

        speed = playerData.walkSpeed;
        isRun = false;
    }
    private void FixedUpdate()
    {
        horizontalMove = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        animator.SetFloat("MoveY", rb2D.velocity.y * Time.deltaTime);
        Move();
    }
    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 && Time.timeScale == 1f)
        {
            if (Input.GetKey(KeyCode.LeftShift) && playerData.inGround)
            {
                isRun = true;
                speed = playerData.runSpeed;
            }else if (playerData.inGround)
            {
                speed = playerData.walkSpeed;
                isRun = false;
            }
            animator.SetBool("IsRun", isRun);
            
            //audioSource.Play();
            transform.position += new Vector3(horizontalMove, 0);
            animator.SetFloat("MoveX", Mathf.Abs(horizontalMove));
        }
    }

    public Vector2 CheckSpeed()
    {
        return new Vector2 (horizontalMove, rb2D.velocity.y);
    }
}
