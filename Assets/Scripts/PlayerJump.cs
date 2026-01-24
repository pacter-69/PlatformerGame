using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;

    public ContactFilter2D filter;

    public int MaxJumpsAir = 1;

    private int jumpsLeft;
    private Rigidbody2D rb;
    private CollisionDetection collisionDetection;
    private float lastVelocityY;
    private float jumpStartedTime;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        collisionDetection = GetComponent<CollisionDetection>();
        jumpsLeft = MaxJumpsAir;
        JumpHeight= 5;
        DistanceToMaxHeight=1.5f;
        SpeedHorizontal=2;
        PressTimeToMaxJump=0.5f;
    }


    void FixedUpdate()
    {
        if (collisionDetection.IsGrounded)
            jumpsLeft = MaxJumpsAir;
        if (IsPeakReached()) TweakGravity();
    }

    // NOTE: InputSystem: "JumpStarted" action becomes "OnJumpStarted" method
    public void OnJumpStarted()
    {
        if (jumpsLeft <= 0) return;
        SetGravity();
        var velocity = new Vector2(rb.linearVelocity.x, GetJumpForce());
        rb.linearVelocity = velocity;
        jumpStartedTime = Time.time;
        jumpsLeft--;
    }

    // NOTE: InputSystem: "JumpFinished" action becomes "OnJumpFinished" method
    public void OnJumpFinished()
    {
        float denom = Mathf.Clamp01((Time.time - jumpStartedTime) / PressTimeToMaxJump);
        if (denom <= 0f) denom = 0.0001f;
        float fractionOfTimePressed = 1f / denom;
        rb.gravityScale *= fractionOfTimePressed;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        float h = -GetDistanceToGround() + JumpHeight;
        Vector3 start = transform.position + new Vector3(-1, h, 0);
        Vector3 end = transform.position + new Vector3(1, h, 0);
        Gizmos.DrawLine(start, end);
        Gizmos.color = Color.white;
    }

    private bool IsPeakReached()
    {
        bool reached = ((lastVelocityY * rb.linearVelocity.y) < 0);
        lastVelocityY = rb.linearVelocity.y;

        return reached;
    }

    private void SetGravity()
    {
        var grav = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        rb.gravityScale = grav / 9.81f;
    }

    private void TweakGravity()
    {
        rb.gravityScale *= 1.2f;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private float GetDistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[3];

        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Ground"))
    {
        jumpsLeft = MaxJumpsAir;
    }
}

}
