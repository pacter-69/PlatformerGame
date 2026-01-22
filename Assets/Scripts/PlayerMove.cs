using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;

    [SerializeField]
    private float JumpForce = 10f;

    bool isGrounded = false;
    public LayerMask groundLayer;

    Rigidbody2D rigidbody;
    private float horizontalDir; // Horizontal move direction value [-1, 1]

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rigidbody.linearVelocity;
        velocity.x = horizontalDir * Speed;
        rigidbody.linearVelocity = velocity;
    }

    void OnMove(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }

    void OnJumpStarted(InputValue jump)
    {
        if (isGrounded)
        {
            Vector2 velocity = rigidbody.linearVelocity;
            velocity.y = JumpForce;
            rigidbody.linearVelocity = velocity;
            isGrounded = false;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // Layer 8 is "Ground"
        { 
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // Layer 8 is "Ground"
        {
            isGrounded = false;
        }
    }
}
