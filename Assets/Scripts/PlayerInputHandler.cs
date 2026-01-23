using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // What inputs can my player do right now?
    // 1. Move left and right
    // 2. Jump
    private Vector2 moveInput;          // Left and right movement
    private bool jumpTriggered = false; // Jumping?

    // Will these private variables need accessing from outside this script?
    // Public properties to read input values
    public Vector2 MoveInput
    {
        get { return moveInput; }
    }

    public bool JumpTriggered
    {
        get { return jumpTriggered; }
    }

    // Both of these are currently wrong 
    // Move event
    public void OnMove(InputAction.CallbackContext context)
    {
        // Save movement inptu into moveInput field
        moveInput = context.ReadValue<Vector2>(); 
    }

    // Jump event
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            jumpTriggered = true;
        }
        else if(context.canceled)
        {
            jumpTriggered = false;
        }
    }
}
