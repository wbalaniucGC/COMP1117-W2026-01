using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
public abstract class Zone : MonoBehaviour
{
    [Header("Zone Settings")]
    [SerializeField] private Color debugColor = new Color(0, 1, 0, 0.3f);

    private BoxCollider2D box;

    protected virtual void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
    }

    // The "contract"
    // Every child object MUST define what happens in this method
    protected abstract void ApplyZoneEffect(Player player);

    // We use a trigger to detect the player
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Ensure that the Player is in the trigger
        if(collision.TryGetComponent(out Player player))
        {
            ApplyZoneEffect(player);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        box = GetComponent<BoxCollider2D>();

        // Safety check
        if (box != null )
        {
            // Box collider 2d exists!
            Gizmos.DrawCube(transform.position + (Vector3)box.offset, box.size);
        }
    }
}
