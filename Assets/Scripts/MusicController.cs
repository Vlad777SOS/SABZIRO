using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;
    public string menuSceneName = "Menu"; // Set the name of the menu scene in the Inspector or directly in code

    private AudioSource audioSource;

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
            return;
        }

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if we are in the menu scene on start
        CheckMusicState(SceneManager.GetActiveScene().name);
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event to detect scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method is called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the music state when the scene changes
        CheckMusicState(scene.name);
    }

    // Function to start or stop the music based on the scene name
    private void CheckMusicState(string sceneName)
    {
        if (sceneName == menuSceneName)
        {
            // Play the music if we are in the menu scene
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop the music if we are not in the menu scene
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
