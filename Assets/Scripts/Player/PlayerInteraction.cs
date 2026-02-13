using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interactions Settings")]
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] private LayerMask interactableLayer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
