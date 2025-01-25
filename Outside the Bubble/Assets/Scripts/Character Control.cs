using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal; // Stores horizontal input
    private float speed = 8f; // Movement speed
    private float jumpingPower = 16f; // Jumping power
    private bool isFacingRight = true; // Tracks facing direction

    [SerializeField] private Rigidbody2D rb; // Rigidbody component for physics
    [SerializeField] private Transform groundCheck; // Position to check if grounded
    [SerializeField] private LayerMask groundLayer; // Layer for ground detection

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Get horizontal input

        // Jump if grounded
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower); // Apply jump force
        }

        //// Reduce jump height if button released
        //if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        //{
        //    rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f); // Modify upward velocity
        //}

        Flip(); // Check and flip character direction
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y); // Apply movement
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // Check if grounded
    }

    private void Flip()
    {
        // Flip character if direction changes
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight; // Toggle facing direction
            Vector3 localScale = transform.localScale; // Get current scale
            localScale.x *= -1f; // Flip the x scale
            transform.localScale = localScale; // Apply new scale
        }
    }
}
