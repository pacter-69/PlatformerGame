using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D rb;
    float horizontalDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontalDir * speed;
        rb.linearVelocity = velocity;
    }

    // Acción "Move" (Vector2)
    void OnMove(InputValue value)
    {
        Vector2 inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }
}
