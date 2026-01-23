using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    // Private variables
    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private int currentHealth;
    private bool isDead = false;

    // Public properties
    public float MoveSpeed
    {
        // Read-only
        get { return moveSpeed; }
    }
    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    public bool IsDead
    {
        // Read-Only
        get { return isDead; }
    }

    // TO-DO: Make changes to Awake
    protected virtual void Awake()
    {
        Debug.Log("Character Awake function");
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Level of Protection
        if(IsDead)
        {
            return;
        }

        // The - "I'm not dead" area
        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} HP is now: {CurrentHealth}");

        // Check if dead
        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} has died.");
    }
}
