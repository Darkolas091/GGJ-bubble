using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck; // Empty GameObject to mark the ground check position
    public Vector2 groundCheckSize = new Vector2(0.4f, 0.2f); // Size of the ground check box
    public LayerMask groundLayer; // Layer to identify the ground
    public LayerMask platformLayer;

    [Header("Wall Check")]
    public Transform wallCheck; // Empty GameObject to mark the wall check position
    public Vector2 wallCheckSize = new Vector2(0.2f, 0.4f); // Size of the wall check box
    public LayerMask wallLayer; // Layer to identify walls

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Handle horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Check if touching a wall
        isTouchingWall = Physics2D.OverlapBox(wallCheck.position, wallCheckSize, 0f, wallLayer);

        // Prevent sticking to the wall
        if (!isTouchingWall || isGrounded)
        {
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        }
        if (isTouchingWall && !isGrounded)
        {
            horizontalInput = 0;
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        }
            
        // Debug log for wall detection
        Debug.Log($"Touching Wall: {isTouchingWall}");

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer) ||
                     Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, platformLayer);

        // Handle jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the ground check box in the Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        }

        // Draw the wall check box in the Scene view
        if (wallCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(wallCheck.position, wallCheckSize);
        }
    }

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
