using UnityEngine;

public class Player : Character
{
    [Header("Player Stats")]
    [SerializeField] private float jumpForce = 12f;             // The force of the jump
    [SerializeField] private LayerMask groundLayer;             // Check to see if I'm standing on the ground layer
    [SerializeField] private Transform groundCheck;             // Position of my ground check.
    [SerializeField] private float groundCheckRadius = 0.2f;    // Size of my ground check

    // Private variables
    private Rigidbody2D rBody;
    private bool isGrounded;
    private PlayerInputHandler input;

    protected override void Awake()
    {
        base.Awake();

        Debug.Log("Player Awake Function");
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update() // Ground check
    {
        // Perform my ground check.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()  // Movement goes here (Move and jump)
    {
        // Handle Movement
        HandleMovement();
        // Handle Jumping
        HandleJump();
        // Optional: Handle Mario-Like Falling
    }

    private void HandleMovement()
    {
        // We get the MoveInput from InputHandler
        // We get MoveSpeed from our Parent Class (Character)
        float horizontalVelocity = input.MoveInput.x * MoveSpeed;

        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);
    }

    private void HandleJump()
    {
        // Only jump if I'm on the ground and input.jumpTriggered is set to true
        if(input.JumpTriggered && isGrounded)
        {
            // Apply the Jump Force
            ApplyJumpForce();
        }
    }

    private void ApplyJumpForce()
    {
        // Reset vertical velocity first to ensure a consistent jump
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
