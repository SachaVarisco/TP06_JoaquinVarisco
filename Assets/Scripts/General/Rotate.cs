using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Look")]
    public bool LookLeft = false;

    [Header("Components")]
    private Rigidbody2D rb2D;
    
    private Vector3 prevPosition;
    private float VelocityX;

    private void FixedUpdate()
    {
        CalcSpeed();
        if (VelocityX > 0.1f && LookLeft)
        {
            RotateX();
        }
        if (VelocityX < -0.1f && !LookLeft)
        {
            RotateX();
        }
    }
    private void CalcSpeed()
    {
        Vector3 currentPosition = transform.position;

        VelocityX = (currentPosition.x - prevPosition.x) / Time.deltaTime;

        prevPosition = currentPosition;
    }
    public void RotateX()
    {
        LookLeft = !LookLeft;

        //gameObject.GetComponent<SpriteRenderer>().flipX = LookLeft;

        Vector3 spriteScale = this.gameObject.transform.localScale;
        spriteScale.x *= -1;  // Invertir la escala en X
        this.gameObject.transform.localScale = spriteScale;

        //transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
