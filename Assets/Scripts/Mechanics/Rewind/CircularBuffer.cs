using System.Collections.Generic;

public class CircularBuffer<T>
{
    // Collection itself
    private List<T> buffer;
    // Capacity
    private int capacity;

    // Constructor - Allowws me to create a CircularBuffer with a given capacity
    public CircularBuffer(int capacity)
    {
        buffer = new List<T>(capacity); 
        this.capacity = capacity;
    }

    // Public Property
    // Read-only Count property
    /*
    public int Count
    {
        get
        {
            return buffer.Count;
        }
    }
    */
    public int Count => buffer.Count;   // The exact same as the read-only property above.


    // Buffer operations
    // =================
    // 1. Push -- Adding new information to the buffer
    public void Push(T item)
    {
        // Check if my buffer is at or above capacity
        if(buffer.Count >= capacity)
        {
            buffer.RemoveAt(0); // Remove the oldest item
        }

        buffer.Add(item);
    }

    // 2. Pop -- Removing the next piece of information from the buffer
    public T Pop()
    {
        if (buffer.Count == 0)
        {
            return default(T);  // Default returns the default value of the datatype T
        }

        int lastIndex = buffer.Count - 1;

        T item = buffer[lastIndex];   // Creates a copy of the item in buffer[lastIndex] and stores it in 'item'
        buffer.RemoveAt(lastIndex);     // Removes the item at lastIndex

        return item;
    }
}
