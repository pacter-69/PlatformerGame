using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;

    [SerializeField]
    private float JumpForce = 10f;

    bool isGrounded = false;

    Rigidbody2D rigidbody;
    private float horizontalDir;// Horizontal move direction value [-1, 1]

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

    // NOTE: InputSystem: "move" action becomes "OnMove" method
    void OnMove(InputValue value)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
