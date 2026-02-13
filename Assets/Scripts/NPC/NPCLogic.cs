using UnityEngine;

public class NPCLogic : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject speechBubble;

    public void Interact()
    {
        // Safety check
        if(speechBubble == null)
        {
            return;
        }

        bool isCurrentlyActive = speechBubble.activeSelf;
        speechBubble.SetActive(!isCurrentlyActive);

        Debug.Log("NPC: Interaction Toggled");
    }
}
