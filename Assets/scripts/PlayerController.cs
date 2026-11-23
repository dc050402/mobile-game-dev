
using UnityEngine;

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
        // Mobile touch input
        bool touchJump = Input.touchCount > 0 &&
                         Input.GetTouch(0).phase == TouchPhase.Began;

        // Keyboard input for Unity Editor testing
        bool keyboardJump = Input.GetKeyDown(KeyCode.Space);

        if ((touchJump || keyboardJump) && isGrounded)
        {
            Jump();
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
    }
}
