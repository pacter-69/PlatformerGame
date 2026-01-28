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

    private float gravityScaleTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionDetection = GetComponent<CollisionDetection>();
        jumpsLeft = MaxJumpsAir;
        JumpHeight = 3;
        DistanceToMaxHeight = 1.5f;
        SpeedHorizontal = 2;
        PressTimeToMaxJump = 0.5f;
    }

    private void Update()
    {
        gravityScaleTimer += Time.deltaTime;

        if (collisionDetection.IsGrounded && gravityScaleTimer >= 0.1f)
        {
            rb.gravityScale = 1;
            gravityScaleTimer = 0;
        }
    }

    void FixedUpdate()
    {
        if (collisionDetection.IsGrounded)
        {
            jumpsLeft = MaxJumpsAir;
        }

        if (IsPeakReached()) TweakGravity();
    }

    private void OnDisable()
    {
        PowerUpManager.OnHeightUpdated -= JumpHeightChange;
    }

    private void OnEnable()
    {
        PowerUpManager.OnHeightUpdated += JumpHeightChange;
    }

    private void JumpHeightChange(int value)
    {
        JumpHeight += value;
    }

    public void OnJumpStarted()
    {
        if (jumpsLeft <= 0) return;
        SetGravity();
        var velocity = new Vector2(rb.linearVelocity.x, GetJumpForce());
        rb.linearVelocity = velocity;
        jumpStartedTime = Time.time;
        jumpsLeft--;
    }

    public void OnJumpFinished()
    {
        float denom = Mathf.Clamp01((Time.time - jumpStartedTime) / PressTimeToMaxJump);
        if (denom <= 0.1f) denom = 0.1f; 
        float fractionOfTimePressed = 1f / denom;
        rb.gravityScale *= fractionOfTimePressed;
        if(rb.gravityScale >= 3.5f) rb.gravityScale = 3.5f; 
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