using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // If you are using TextMeshPro for the percentage text
using UnityEngine.SceneManagement;

public class LoadingBarManager : MonoBehaviour
{
    public Slider progressBar; // Reference to the UI slider (progress bar)
    public TextMeshProUGUI progressText; // Reference to the percentage text
    public float loadDuration = 4f; // How long the loading takes (in seconds)
    public string nextSceneName; // Name of the scene to load

    private float loadProgress = 0f; // Current progress (between 0 and 1)

    void Start()
    {
        // Start simulating the loading progress
        StartCoroutine(SimulateLoading());
    }

    IEnumerator SimulateLoading()
    {
        // Simulate progress over time
        while (loadProgress < 1f)
        {
            // Increment progress based on the load duration
            loadProgress += Time.deltaTime / loadDuration;

            // Update the progress bar value
            progressBar.value = loadProgress;

            // Update the text to show the percentage (e.g., "Loading 50%")
            progressText.text = "Loading " + Mathf.FloorToInt(loadProgress * 100) + "%";

            yield return null; // Wait for the next frame
        }

        // Ensure the progress bar reaches 100% at the end
        progressBar.value = 1f;
        progressText.text = "Loading 100%";

        // After loading completes, transition to the next scene
        yield return new WaitForSeconds(0.5f); // Optional: small delay at 100%
        SceneManager.LoadScene(nextSceneName);
    }
}
