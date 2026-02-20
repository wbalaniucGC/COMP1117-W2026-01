using UnityEngine;

public class Gem : MonoBehaviour
{
    public void DoGemStuff()
    {
        Debug.Log("<color=cyan> SPARKLE SPARKLE SPARKLE </color>");
        GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}
