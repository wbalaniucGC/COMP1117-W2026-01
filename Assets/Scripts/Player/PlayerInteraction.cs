using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interactions Settings")]
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] private LayerMask interactableLayer;

    public void OnInteract(InputAction.CallbackContext context)
    {
        // Fires once when pressed
        if(context.started)
        {
            PerformInteraction();
        }
    }

    private void PerformInteraction()
    {
        // Find everything in a circle around the fox on the "interactable" layer
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);

        // Safety check
        if(hit != null)
        {
            if(hit.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
                Debug.Log($"Interacted with {hit.name}");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
