using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    void Awake()
    {
        // Check if an instance of MusicController already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserve this GameObject across scene transitions
        }
        else
        {
            // If an instance already exists, destroy this new one to avoid duplicates
            Destroy(gameObject);
        }
    }
}
