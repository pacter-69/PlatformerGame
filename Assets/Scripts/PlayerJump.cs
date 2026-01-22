using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;

    Rigidbody2D rb;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Acción "Jump" (Button) -> PlayerInput (Send Messages) llamará a OnJump
    void OnJumpStarted(InputValue value)
    {
        if (!value.isPressed) return;
        if (!isGrounded) return;

        Vector2 v = rb.linearVelocity;
        v.y = jumpForce;
        rb.linearVelocity = v;

        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            // Debug para saber si detecta suelo:
            Debug.Log("Grounded TRUE");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Grounded FALSE");
        }
    }
}
