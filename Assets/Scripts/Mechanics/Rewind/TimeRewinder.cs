using UnityEngine;
using UnityEngine.InputSystem;

public class TimeRewinder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxFrames = 300;
    public bool isRewinding = false;                // Optional visual reference to know when you are rewinding.

    private CircularBuffer<Vector3> positionHistory;
    private CircularBuffer<Quaternion> rotationHistory;
    private CircularBuffer<Vector3> scaleHistory;

    private void Awake()
    {
        positionHistory = new CircularBuffer<Vector3>(maxFrames);
        rotationHistory = new CircularBuffer<Quaternion>(maxFrames);
        scaleHistory = new CircularBuffer<Vector3>(maxFrames);
    }

    public void OnRewind(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isRewinding = true;
            Debug.Log("Rewind started");
        }
        else if(context.canceled)
        {
            isRewinding = false;
            Debug.Log("Rewind cancelled");
        }
    }

    private void FixedUpdate()
    {
        if (!isRewinding)
        {
            Record();
        }
        else
        {
            Rewind();
        }
    }

    // Record - Records information every frame
    private void Record()
    {
        positionHistory.Push(transform.position);
        rotationHistory.Push(transform.rotation);
        scaleHistory.Push(transform.localScale);
    }
    // Rewind - Retrieves information every frame from the buffer
    private void Rewind() 
    {
        if(rotationHistory.Count > 0)
        {
            transform.position = positionHistory.Pop();
            transform.rotation = rotationHistory.Pop();

            Vector3 tempLocalScale = scaleHistory.Pop();
            transform.localScale = new Vector3(tempLocalScale.x * -1, tempLocalScale.y, tempLocalScale.z);
        }
        else
        {
            Debug.Log("Rewind stopped due to lack of information");
            isRewinding = false;
        }
    }
}
