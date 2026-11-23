
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mobile touchscreen input
        bool touchJump = Touchscreen.current != null &&
                         Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        // Keyboard input for testing in Unity Editor
        bool keyboardJump = Keyboard.current != null &&
                            Keyboard.current.spaceKey.wasPressedThisFrame;

        if ((touchJump || keyboardJump) && isGrounded)
        {
            Jump();
        }

        if (transform.position.y < -6f)
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
    }

}
