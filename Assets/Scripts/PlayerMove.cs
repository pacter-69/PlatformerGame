using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D rb;
    float horizontalDir;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (horizontalDir > 0) GetComponent<SpriteRenderer>().flipX = false;

        if (horizontalDir < 0) GetComponent<SpriteRenderer>().flipX = true;

        if (horizontalDir != 0) animator.SetBool("isRunning", true);
        else animator.SetBool("isRunning", false);
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontalDir * speed;
        rb.linearVelocity = velocity;
    }

    void OnMove(InputValue value)
    {
        Vector2 inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }
}