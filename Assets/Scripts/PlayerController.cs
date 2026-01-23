using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character
{
    // Components
    private Rigidbody2D rBody;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

    }
}
