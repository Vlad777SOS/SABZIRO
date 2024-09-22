using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LaunchFade : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component used for the fade effect
    public float fadeDuration = 2f; // Duration of the fade effect (in seconds)

    private void Start()
    {
        // Start the fade-in effect when the game begins
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("Fade-in started");  // Log when the fade-in starts

        // Ensure the fade image is fully opaque (black) at the start
        fadeImage.color = new Color(0, 0, 0, 1);

        // Gradually reduce the alpha value to make the image transparent (fade-in)
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration); // Linearly interpolate alpha from 1 (opaque) to 0 (transparent)
            fadeImage.color = new Color(0, 0, 0, alpha); // Set the new alpha value
            yield return null; // Wait for the next frame
        }

        // Ensure it's fully transparent at the end of the fade-in
        fadeImage.color = new Color(0, 0, 0, 0);

        // Optionally disable the fade image (but NOT the entire UI Canvas)
        fadeImage.gameObject.SetActive(false);

        Debug.Log("Fade-in completed");  // Log when the fade-in finishes
    }
}
