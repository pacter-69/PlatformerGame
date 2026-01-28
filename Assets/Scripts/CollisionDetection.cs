using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask WhatIsGround;
    [SerializeField]
    private LayerMask WhatIsPlatform;

    [SerializeField]
    private Transform GroundCheckPoint;
    [SerializeField]
    private Transform RoofCheckPoint;

    public Transform CurrentPlatform;

    private float checkRadius = 0.15f;

    private Animator animator;

    [SerializeField]
    private bool isGrounded;

    public bool IsGrounded { get { return isGrounded; } }

    [SerializeField]
    private float distanceToGround;

    public float DistanceToGround { get { return distanceToGround; } }

    [SerializeField]
    private float groundAngle;

    public float GroundAngle { get { return groundAngle; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheckPoint.position, checkRadius);
        Gizmos.color = Color.white;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isJumping", !isGrounded);
    }

    void FixedUpdate()
    {
        CheckCollisions();
        CheckDistanceToGround();
    }

    private void CheckCollisions()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCheckPoint.position, checkRadius, WhatIsGround);
        isGrounded = (colliders.Length > 0);
    }

    private void CheckDistanceToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundCheckPoint.position, Vector2.down, 100, WhatIsGround);

        distanceToGround = hit.distance;
        groundAngle = Vector2.Angle(hit.normal, new Vector2(1, 0));
    }
}