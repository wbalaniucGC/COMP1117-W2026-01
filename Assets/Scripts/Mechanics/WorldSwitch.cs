using UnityEngine;
using UnityEngine.Events;

public class WorldSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private UnityEvent onActivated;

    private SpriteRenderer sRend;
    private bool isFlipped = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        isFlipped = !isFlipped; // Flips isFlipped

        sRend.sprite = isFlipped ? onSprite : offSprite;        // Ternary statement
        /*
        if (isFlipped)
        {
            sRend.sprite = onSprite;
        }
        else if(!isFlipped)
        {
            sRend.sprite = offSprite;
        }
        */

        if(isFlipped)
        {
            onActivated.Invoke();
        }
    }
}
