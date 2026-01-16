using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5.0f;
    [SerializeField] private int initialHealth = 100;


    private PlayerStats stats;

    // Components
    Rigidbody2D rBody;

    // Private variables
    Vector2 moveInput;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

        stats = new PlayerStats(initialSpeed, initialHealth);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        Debug.Log(stats.MoveSpeed);
    }

    private void ApplyMovement()
    {
        float targetVelocityX = moveInput.x * stats.MoveSpeed;

        rBody.linearVelocity = new Vector2(targetVelocityX, rBody.linearVelocity.y);
    }
}
