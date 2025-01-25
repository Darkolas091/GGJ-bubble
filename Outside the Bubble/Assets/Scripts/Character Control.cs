using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        if (horizontal < 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump") && grounded)
            Jump();
    }

    private void Jump()
    {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }


}
